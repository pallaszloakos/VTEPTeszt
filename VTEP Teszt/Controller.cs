using System;
using System.ComponentModel.Design.Serialization;


/*
 *  Controller osztály 
 * 
 * 
 */
public class Controller
{
    private DevicesFacade Model;
    private Storage FileSaver;

    public Controller()
    {
        Model = new DevicesFacade();
        FileSaver = new Storage();

    }


    /* Egyszeru Queue megvalosítás, esetleges eroforras problak eseteben, sem maradunk le egy viszateresi ertekrol.
	 *
	 */
    public ref Queue<string> GetQueue()
    {

        return ref Model.ResposeQueue;
    }
    public void Start()
    {
        Model.Start();
    }

    public void Stop()
    {
        Model.Stop();
    }

    public bool Status()
    {
        return Model.GetStatus();
    }

    public void Save(string content, string filename)
    {
        FileSaver.Save(content, filename);
    }



    public bool Validate(string ErrorCode)
    {
        return Model.Validate(ErrorCode);
    }
}
