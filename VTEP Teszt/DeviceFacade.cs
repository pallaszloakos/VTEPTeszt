using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using GetID;


/*
 
 Egy nagyon egyszeru Facade pattern, igy akar tobbfajta eltero methodusokkal rendelkezo osztaly is hasznalhato majd a kesobbiekben. 
 
 */
public class DevicesFacade
{
    public Queue<string> ResposeQueue;
    private GetID.GetID Device;
	private string ValidatorString = "^[A-Z]\\d{4}$";

    /*
	 Constructok, amely letrehozza a Dll-bol az instance-t, es feliratkozik az esemenyekre. 
	 
	 */
    
    public DevicesFacade()
	{
    
        ResposeQueue = new Queue<string>();
        Device = new GetID.GetID();
		Device.ValueChanged += c_ValueChange;
		Device.ErrorChanged += c_ErrorChanged;
        
    }

    public void Start()
	{
		Device.Go();
		
	}

	
	public void Stop()
	{
		Device.Stop();
	}
	
	private void c_ValueChange(object sender, EventArgs e)
	{
		ResposeQueue.Enqueue(Device.Value);
	}

	private void c_ErrorChanged(object sender, EventArgs e)
	{
		MessageBox.Show(Device.ErrorMessage);
	}

	public bool GetStatus()
	{
		return Device.Running;
	}
	
	public bool Validate(string ErrorCode)
	{
        Regex rgx = new Regex(ValidatorString);
		return rgx.IsMatch(ErrorCode);
    }
}
