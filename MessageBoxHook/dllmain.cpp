#include <cstdio>
#include <windows.h>
#include <tchar.h>
#include "detours.h"

int (WINAPI* pMessageBox)(HWND hWnd, LPCTSTR lpText, LPCTSTR lpCaption, UINT uType) = MessageBox;
int WINAPI MyMessageBox(HWND hWnd, LPCTSTR lpText, LPCTSTR lpCaption, UINT uType)
{
	int ret = IDYES; //pMessageBox(hWnd, TEXT("injection success\n"), lpCaption, uType);
	//int ret = pMessageBox(hWnd, TEXT("injection success\n"), lpCaption, uType);
	return ret;
}

int DllProcessAttach(void)
{
	DetourRestoreAfterWith();
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	DetourAttach(&(PVOID&)pMessageBox, MyMessageBox);
	if (DetourTransactionCommit() == NO_ERROR) {
		OutputDebugString(TEXT("MessageBox() detoured successfully"));
		return -1;
	}
	return 0;
}

int DllProcessDetach(void)
{
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	DetourAttach(&(PVOID&)pMessageBox, MyMessageBox);
	DetourTransactionCommit();
	return 0;
}

BOOL WINAPI DllMain(HINSTANCE hIn, DWORD dwReason, LPVOID lpvoid) {
	switch (dwReason) {
	case DLL_PROCESS_ATTACH:
		OutputDebugString(TEXT("Process Attach"));
		DisableThreadLibraryCalls(hIn);
		DllProcessAttach();
		break;
	case DLL_PROCESS_DETACH:
		OutputDebugString(TEXT("Process Detach"));
		DllProcessDetach();
		break;
	default:
		break;
	}
	return TRUE;
}
