﻿
#include <iostream>
#include <Windows.h>

int main(int argc, char* argv[])
{
	if (argc != 3) {
		std::cout << "Process id and dll path are required.";
		return 1;
	}

	int processId = atoi(argv[1]);
	const char* path = argv[2];
	std::cout << "Supplied process id " << processId << std::endl << "Dll path: " << path << std::endl;

	// path to our dll
	LPCSTR DllPath = path;

	// Open a handle to target process
	HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, processId);

	// Allocate memory for the dllpath in the target process
	// length of the path string + null terminator
	LPVOID pDllPath = VirtualAllocEx(hProcess, 0, strlen(DllPath) + 1,
		MEM_COMMIT, PAGE_READWRITE);

	// Write the path to the address of the memory we just allocated
	// in the target process
	WriteProcessMemory(hProcess, pDllPath, (LPVOID)DllPath,
		strlen(DllPath) + 1, 0);

	// Create a Remote Thread in the target process which
	// calls LoadLibraryA as our dllpath as an argument -> program loads our dll
	HANDLE hLoadThread = CreateRemoteThread(hProcess, 0, 0,
		(LPTHREAD_START_ROUTINE)GetProcAddress(GetModuleHandleA("Kernel32.dll"),
			"LoadLibraryA"), pDllPath, 0, 0);

	// Wait for the execution of our loader thread to finish
	WaitForSingleObject(hLoadThread, INFINITE);

	std::cout << "Dll path allocated at: " << std::hex << pDllPath << std::endl;
	//std::cin.get();

	// Free the memory allocated for our dll path
	VirtualFreeEx(hProcess, pDllPath, strlen(DllPath) + 1, MEM_RELEASE);

	return 0;
}