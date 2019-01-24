﻿#include <windows.h>
#include <tchar.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
TCHAR WinName[] = _T("MainFrame");

int APIENTRY _tWinMain(
	HINSTANCE This, // Дескриптор текущего приложения
	HINSTANCE Prev, // В современных системах всегда 0
	LPTSTR cmd, // Командная строка
	int mode) // Режим отображения окна
{
	HWND hWnd; // Дескриптор главного окна программы
	MSG msg; // Структура для хранения сообщения
	WNDCLASS wc; // Класс окна
				 // Определение класса окна
	wc.hInstance = This;
	wc.lpszClassName = WinName; // Имя класса окна
	wc.lpfnWndProc = WndProc; // Функция окна
	wc.style = CS_HREDRAW | CS_VREDRAW; // Стиль окна
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION); // Стандартная иконка
	wc.hCursor = LoadCursor(NULL, IDC_ARROW); // Стандартный курсор
	wc.lpszMenuName = NULL; // Нет меню
	wc.cbClsExtra = 0; // Нет дополнительных данных класса
	wc.cbWndExtra = 0; // Нет дополнительных данных окна
					   // Заполнение окна белым цветом
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	if (!RegisterClass(&wc)) return 0; // Регистрация класса окна
									   // Создание окна
	hWnd = CreateWindow(WinName, // Имя класса окна
		_T("Каркас Windows-приложения"), // Заголовок окна
		WS_OVERLAPPEDWINDOW, // Стиль окна
		CW_USEDEFAULT, // x
		CW_USEDEFAULT, // y Размеры окна
		CW_USEDEFAULT, // width8 ИОтОрфОйс WinИoИИ­прООожОООИ КОркОс WinИoИИ­прООожОООИ
		CW_USEDEFAULT, // Height
		HWND_DESKTOP, // Дескриптор родительского окна
		NULL, // Нет меню
		This, // Дескриптор приложения
		NULL); // Дополнительной информации нет
	ShowWindow(hWnd, mode); // Показать окно
							// Цикл обработки сообщений
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg); // Функция трансляции кодов нажатой клавиши
		DispatchMessage(&msg); // Посылает сообщение функции WndProc()
	}
	return 0;
}
// Оконная функция вызывается операционной системой
// и получает сообщения из очереди для данного приложения
LRESULT CALLBACK WndProc(
	HWND hWnd,
	UINT message,
	WPARAM wParam,
	LPARAM lParam)
{ // Обработчик сообщений
	switch (message)
	{
		case WM_DESTROY: PostQuitMessage(0);
			break; // Завершение программы
				   // Обработка сообщения по умолчанию
		default: return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}
