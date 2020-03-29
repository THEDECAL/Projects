package FileCopyInThreads;
import FileCopyInThreads.Models.FileManager;

import java.io.File;
import java.util.Scanner;
import java.util.function.Predicate;

public class Main {
    static final private Integer FILE_COUNT_TO_COPY = 2;

    public static void main(String[] args) {
        while(true) {
            try {
                var srcPath = inputFilePath("Введите путь к файлу источнику копирования: ", FileManager::FileExists);
                var dstPath = inputFilePath("Введите путь к файлу назначения копирования: ", FileManager::CheckFolderByFilePath);

                new Thread(() ->
                {
                    try { FileManager.Copy(srcPath, dstPath); }
                    catch(Exception ex){ System.out.print(ex.getMessage() + '\n'); }
                }).start();

            } catch (Exception ex) { System.out.print(ex.getMessage() + '\n'); }
        }
    }

    static private String inputFilePath(String inviteText, Predicate<String> condition) throws Exception{
        if(condition == null) condition = text -> true;

        while(true) {
            var scanner = new Scanner(System.in);
            System.out.print(inviteText + '\n');
            var path = scanner.nextLine();

            if (!condition.test(path))
                throw new Exception("Файл или папка не найдена либо нет прав на запись в папке.");

            return path;
        }
    }
}
