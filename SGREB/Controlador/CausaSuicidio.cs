
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CausaSuicidio {

    public CausaSuicidio() {
    }

    private int idCausa;

    private string nCausaSuicidio;

    public CausaSuicidio(string causaSuicidio)
    {
        nCausaSuicidio = causaSuicidio;
    }

    public CausaSuicidio(int idCausa, string causaSuicidio):this(causaSuicidio)
    {
        this.idCausa = idCausa;
    }

    public List<TV_CausaSuicidio> obtenerTodos()
    {
        var bitacora = new bitacoraBomberoaContext();
        var tvCausaSuicidos = bitacora.TV_CausaSuicidio;
        return tvCausaSuicidos.ToList();
    }

    public void crear()
    {
        var bitacora = new bitacoraBomberoaContext();
        var tvCausaSuicido = new TV_CausaSuicidio();
        tvCausaSuicido.CausaSuicidio = this.nCausaSuicidio;
        bitacora.TV_CausaSuicidio.Add(tvCausaSuicido);
        bitacora.SaveChanges();
    }
    public TV_CausaSuicidio obtener(int id)
    {
        var bitacora = new bitacoraBomberoaContext();
        var tvCausaSuicido = bitacora.TV_CausaSuicidio.Where(s => s.idCausa == id).Single();
        return tvCausaSuicido;
    }

    public void modificar(CausaSuicidio causaSuicidio)
    {
        using (var bitacora = new bitacoraBomberoaContext())
        {
            var tvCausaSuicido = bitacora.TV_Animal.Find(causaSuicidio.idCausa);
            tvCausaSuicido.tipo = causaSuicidio.nCausaSuicidio;
            bitacora.SaveChanges();
        }
    }
}