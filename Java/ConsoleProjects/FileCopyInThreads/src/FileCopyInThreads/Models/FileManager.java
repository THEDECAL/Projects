package FileCopyInThreads.Models;
import java.io.*;
import java.util.concurrent.Semaphore;

public class FileManager{
    static private Integer QUEUE_LENGTH = 2;
    static private Semaphore semaphore = new Semaphore(QUEUE_LENGTH);

    static public void Copy(String srcFilePath, String dstFilePath) throws Exception {
        if (srcFilePath != null && dstFilePath != null) {
            try {
                System.out.print("Копирование файла \"" + srcFilePath + "\" в \"" + dstFilePath + "\" поставлено в очередь.\n");
                semaphore.acquire();

                try (var fis = new FileInputStream(srcFilePath)) {
                    try (var fos = new FileOutputStream(dstFilePath)) {
                        var buffer = new byte[256];
                        var count = -1;

                        System.out.print("Копирование файла \"" + srcFilePath + "\" в \"" + dstFilePath + "\" начато.\n");

                        while (fis.available() > 0) {
                            count = fis.read(buffer, 0, buffer.length);
                            fos.write(buffer, 0, count);
                        }

                        System.out.print("Копирование файла \"" + srcFilePath + "\" в \"" + dstFilePath + "\" завершено.\n");
                    } catch (IOException ex) { throw new Exception(ex.getMessage()); }
                } catch (IOException ex) { throw new Exception(ex.getMessage()); }

                semaphore.release();
            } catch (InterruptedException ex) { throw new Exception(ex.getMessage()); }
        } else throw new NullPointerException();
    }
    static public Boolean FileExists(String pathToFile) {
        if(pathToFile != null && pathToFile != "") {
            var file = new File(pathToFile);
            return file.exists() && !file.isDirectory();
        }
        return false;
    }
    static public Boolean FileCanWrite(String path) {
        if(path != null && path != "") {
            var file = new File(path);
            return file.canWrite();
        }
        return false;
    }
    static public Boolean FolderExists(String pathToFolder) {
        if(pathToFolder != null && pathToFolder != "") {
            var folder = new File(pathToFolder);
            return folder.exists() && folder.isDirectory();
        }
        return false;
    }
    static public Boolean CheckFolderByFilePath(String pathToFile) {
        if(pathToFile != null && pathToFile != "") {
            var folder = new File(new File(pathToFile).getParent());
            return folder.exists() && folder.isDirectory() && folder.canWrite();
        }
        return false;
    }
}
