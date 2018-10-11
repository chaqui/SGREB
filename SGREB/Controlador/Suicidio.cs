
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Suicidio  {

    public Suicidio() {
    }

    public int crearSuiciidio(TC_Suicidio suicidio)
    {
        var bitacora = new bitacoraBomberoaContext();
        bitacora.TC_Suicidio.Add(suicidio);
        bitacora.SaveChanges();
        return suicidio.idSuicidio;
    }


}