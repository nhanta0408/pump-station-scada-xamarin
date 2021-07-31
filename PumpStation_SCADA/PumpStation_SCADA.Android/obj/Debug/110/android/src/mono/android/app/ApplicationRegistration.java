package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("MainApplication, PumpStation_SCADA.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64ea1ff489c2c71ba2.MainApplication.class, crc64ea1ff489c2c71ba2.MainApplication.__md_methods);
		
	}
}
