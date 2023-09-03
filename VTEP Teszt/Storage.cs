using System;


/*
 
Kulon osztaly a file muveleteknek. 
 
 */
public class Storage
{
    public Storage()
    {

    }


    /*
     *  Nagy mennyisegi adatnal itt celszerubb lett volna referenciakent atadni at adatokat, mert igy memoira problemakat tud majd okozni. 
     *  De ezt itt nem fejtettem ki.
     */
    public void Save(string content, string filename)
    {

        Task.Run(() => SaveTask(content, filename));

    }

    private void SaveTask(string content, string filename)
    {
        /*
        Elvileg a dialog-bol nem johet ures filename, dehat ki tudja.
      */
        if (filename is not null)
        {
            var textfile = OpenStream(filename);
            if (textfile is null)
                return;
            textfile.WriteLine(content);
            textfile.Close();
            MessageBox.Show("A mentés sikeres volt.");
        }
        else
        {
            MessageBox.Show("Class_Storage: Empty filename!");
        }

    }

    /*
     Elkapni az osszes filemuvelettel kapcsolatos hibat. Google a baratom.     
    */
    static StreamWriter? OpenStream(string path)
    {
        if (path is null)
        {
            MessageBox.Show("Class_Storage: You did not supply a file path.");
            return null;
        }

        try
        {
            var fs = new FileStream(path, FileMode.CreateNew);
            return new StreamWriter(fs);
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("Class_Storage: The file or directory cannot be found.");
        }
        catch (DirectoryNotFoundException)
        {
            MessageBox.Show("Class_Storage: The file or directory cannot be found.");
        }
        catch (DriveNotFoundException)
        {
            MessageBox.Show("Class_Storage: The drive specified in 'path' is invalid.");
        }
        catch (PathTooLongException)
        {
            MessageBox.Show("Class_Storage: 'path' exceeds the maximum supported path length.");
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Class_Storage: You do not have permission to create this file.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            MessageBox.Show("Class_Storage: There is a sharing violation.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
        {
            MessageBox.Show("Class_Storage: The file already exists.");
        }
        catch (IOException e)
        {
            MessageBox.Show($"Class_Storage: An exception occurred:\nError code: " +
                              $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
        }
        return null;
    }

}
