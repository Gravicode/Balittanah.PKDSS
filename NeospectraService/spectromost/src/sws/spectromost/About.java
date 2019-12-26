package sws.spectromost;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import javax.swing.JDialog;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JTextArea;
import java.awt.Color;

public class About extends JDialog {

	/**
	 * 
	 */
	private static final long	serialVersionUID	= -136366932428577374L;
	private final JPanel		contentPanel		= new JPanel();

	/*! 
	 * Create the dialog. 
	 */
	public About()
	{
		setTitle("About!");
		setBackground( new Color( 176, 196, 222));
		getContentPane().setBackground( new Color( 176, 196, 222));
		setResizable( false);
		setBounds( 100,
				100,
				450,
				125);
		getContentPane().setLayout( new BorderLayout());
		contentPanel.setBackground( new Color( 176, 196, 222));
		contentPanel.setLayout( new FlowLayout());
		contentPanel.setBorder( new EmptyBorder( 5, 5, 5, 5));
		getContentPane().add( contentPanel,
				BorderLayout.CENTER);
		{
			JTextArea txtrSoftwareLynx = new JTextArea();
			txtrSoftwareLynx.setBorder( null);
			txtrSoftwareLynx.setEditable( false);
			txtrSoftwareLynx.setBackground( new Color( 176, 196, 222));
			Package p = getClass().getPackage();
			String version = p.getSpecificationVersion() + "." + p.getImplementationVersion();
			txtrSoftwareLynx.setText( "Software : SpectroMOST \u2122 \u00A9 2016 SWS.\r\nVersion : " + version + "\r\nProvided by : Si-Ware Systems.\r\nWebsite: www.si-ware.com\r\nFor assistance please contact neospectra.support@si-ware.com");
			contentPanel.add( txtrSoftwareLynx);
		}
	}

}
