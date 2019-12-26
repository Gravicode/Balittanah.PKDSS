package sws.spectromost;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.io.File;

import javax.swing.JOptionPane;

import sws.p2AppManager.utils.p2Constants;
import sws.spectromost.SetDataWave;

public class JsonJackson {
	private double[] WaveNumber;
	private double[] Absorbance;
	private String filename;
	
	/*
	 * ! gets the path of running application
	 */
	public static String APPLICATION_WORKING_DIRECTORY = p2Constants.Original_APPLICATION_WORKING_DIRECTORY;
	
	/*
	 * datetime format as filename
	 */	
	public void setFileName()
	{
		DateFormat dateFormat = new SimpleDateFormat("yyyyMMdd_HHmmss");
		Date date = new Date();
		this.filename = dateFormat.format(date);
	}
	
	public void WriteJson(double[] wave, double[] abs)
	{				
		setFileName();
		this.WaveNumber = wave;
		this.Absorbance = abs;
		
		ObjectMapper mapper = new ObjectMapper();		
		SetDataWave Data = setdatawave(wave, abs);
		
		/**
         * Write object to file
         */
        try 
        {
        	File file = new File(APPLICATION_WORKING_DIRECTORY + File.separatorChar + "result");
            if (!file.exists()) 
            {
            	file.mkdir();
            }
        	
        	// Convert object to JSON string and save into a file directly
            mapper.writeValue(new File(APPLICATION_WORKING_DIRECTORY + File.separatorChar + "result" + File.separatorChar + filename +".json"), Data);//Plain JSON
         
            // Convert object to JSON string and pretty print
            //mapper.writerWithDefaultPrettyPrinter().writeValue(new File("result.json"), carFleet);//Prettified JSON
            
            // Convert object to JSON string
         	//String jsonInString = mapper.writeValueAsString(wave);
         	//System.out.println(jsonInString);
        } 
        catch (Exception e) 
        {
            e.printStackTrace();
        }
		
	}
			
	public SetDataWave setdatawave(double[] wavedata, double[] absdata)
	{
		SetDataWave setData = new SetDataWave();
		setData.setWavenumber(wavedata);
		setData.setAbsorbance(wavedata);
		
		return setData;
	}
}
