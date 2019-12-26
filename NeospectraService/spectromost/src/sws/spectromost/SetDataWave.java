package sws.spectromost;

import java.util.ArrayList;
import java.util.List;

import javax.swing.JOptionPane;

public class SetDataWave {
	
	private double[] Wavenumber;
	private double[] Absorbance;
	
	//setter getter Methode	
	public void setWavenumber(double[] wave){this.Wavenumber = wave;}
	public double[] getWavenumber(){return this.Wavenumber;}
	public void setAbsorbance(double[] abs){this.Absorbance = abs;}
	public double[] getAbsorbance(){return this.Absorbance;}
}
