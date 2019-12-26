package sws.spectromost;

public class VariableHelper {
	
	//declare variable
	private static String message;
	private static boolean status;
	
	//message
	public static void setMessage(String Message) {message = Message;}
	public static String getMessage() {return message;}
	
	//status
	public static void setStatus(boolean Status) {status = Status;}
	public static boolean getStatus() {return status;}
}
