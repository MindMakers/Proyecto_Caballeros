using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Text;

public class manejadorXML : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
        string[] aux = new string[300] ; 

        string path = "Assets/xml/Dialogos.xml";
        
        string readText = File.ReadAllText(path);
        print(readText);
        int i = 0;
        StringBuilder output = new StringBuilder();

        using (XmlReader reader = XmlReader.Create(new StringReader(readText)))
        {
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(output, ws))
            {

                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            writer.WriteStartElement(reader.Name);
                           // print(reader.Value);
                            break;
                        case XmlNodeType.Text:
                            writer.WriteString(reader.Value);
                            //print(reader.Name);
                            aux[i] = reader.Value;
                            i++;
                            break;
                        case XmlNodeType.XmlDeclaration:
                        case XmlNodeType.ProcessingInstruction:
                            writer.WriteProcessingInstruction(reader.Name, reader.Value);
                           // print(reader.Name);
                           // print(reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            writer.WriteComment(reader.Value);
                          //  print(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            writer.WriteFullEndElement();
                            break;
                    }
                }

            }
        }
        string[] auxNombres = new string[50];
        string[][] auxArrays;
        int contadorNombres = 0;
        for (i=0; i<aux.Length; i++)
        {
         
            if (esPar(i))
            {
                if (!estaEnElArray(aux[i], auxNombres))
                {
                    auxNombres[contadorNombres] = aux[i];
                    contadorNombres++;
                }
            }   
            

        }

        auxArrays = new string[contadorNombres][];

        for (i=0; i<auxArrays.GetLength(0); i++)
        {
            auxArrays[i] = new string[200];
        }

        int[] contadoresArray = new int[auxNombres.Length];
        for (i=0; i<contadoresArray.Length; i++)
        {
            contadoresArray[i] = 0;

        }
		for (i=0; i<aux.Length && aux[i] != null; i+=2)
        {
			auxArrays[devolverIndice(aux[i], auxNombres)][contadoresArray[devolverIndice(aux[i], auxNombres)]] = aux[i+1];
            contadoresArray[devolverIndice(aux[i], auxNombres)]++;
        }

        GameObject[] auxGames = GameObject.FindGameObjectsWithTag("Habla");
        for (i=0; i<auxGames.Length; i++)
        {
            
            auxGames[i].GetComponent<iSpeak>().setArrayConver(auxArrays[devolverIndice(auxGames[i].GetComponent<iSpeak>().id, auxNombres)]);

        }

    }
	
	private bool esPar(int i)
    {
        return i % 2 == 0;  

    }

    private bool estaEnElArray(string nombre, string[] array)
    {
        int i;
        bool res = false;
        for (i=0; i < array.Length; i++)
        {
            if (array[i] == nombre)
            {
                res = true;
            }
        }
        return res;
    }


    private int devolverIndice(string nombre, string[] aux)
    {
		string auxa = fueraEspacios(nombre);
		string auxr;
		
        for (int i= 0; i<aux.Length; i++)
        {
			auxr = fueraEspacios( aux [i]);
			if (auxr == auxa )
            {
                return i;
            }
        }

        return -1;
    }

	private string fueraEspacios (string nombre){
		string aux = "";
		string n = nombre;
		char [] adux = n.ToCharArray();

		for (int i = 0; i < adux.Length; i++) {
			if (adux [i] != '\t' && adux [i] != '\n' && adux [i] != ' ' && adux[i] != '\r') {
				aux += adux [i];
			}
		}
		return aux;
	}


}
