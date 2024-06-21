using System.Windows;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;
public class Script
{
  [Start]
  public void XEsGetPropertyAction_Start()
  {
	  
	  
	//Esta es la opción de ver la información en Projectinfo.xml en 2020  
	/*  
    CommandLineInterpreter cli = new CommandLineInterpreter();
    ActionCallingContext acc = new ActionCallingContext();
    string propertyValue = string.Empty;
    acc.AddParameter("PropertyId", "20100"); //20100 = PartNumber
    acc.AddParameter("PropertyIndex", "1");
    cli.Execute("XEsGetPropertyAction", acc);
    acc.GetParameter("PropertyValue", ref propertyValue);
    MessageBox.Show(propertyValue);*/



    //Para versiones anteriores o en todas las versiones de eplan se puede hacer esta consulta
	CommandLineInterpreter oCLI = new CommandLineInterpreter();
	string XmlFile = PathMap.SubstitutePath("$(PROJECTPATH)" + @"\Projectinfo.xml");
	string projectType = "";
	bool sRet = false;
	
	XmlTextReader objReader = new XmlTextReader(XmlFile);
	
	while (objReader.Read())
        {
            if (objReader.HasAttributes) 
            {
                while (objReader.MoveToNextAttribute()) 
                {
                    if (objReader.Name == "id")
                    {
                        if (objReader.Value == "10902")
                        {
							projectType = objReader.ReadString();							
							MessageBox.Show(projectType);		
                        }
                    }
                }
            }
        } 	
  }
}