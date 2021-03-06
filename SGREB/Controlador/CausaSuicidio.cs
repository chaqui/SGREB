
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// clase que controla las conexiones con la tabla 
/// causa intoxicación de la base de datos 
/// </summary>
public class CausaSuicidio {
    /// <summary>
    /// constructor para las funcionalidades de la clase
    /// </summary>
    public CausaSuicidio() {
    }

    private int idCausa { get; set; }

    private string nCausaSuicidio;

    /// <summary>
    /// constructor para la creación 
    /// </summary>
    /// <param name="causaSuicidio"></param>
    public CausaSuicidio(string causaSuicidio)
    {
        nCausaSuicidio = causaSuicidio;
    }
    /// <summary>
    /// constructor para la selección y actualizaación
    /// </summary>
    /// <param name="idCausa"></param>
    /// <param name="causaSuicidio"></param>
    public CausaSuicidio(int idCausa, string causaSuicidio):this(causaSuicidio)
    {
        this.idCausa = idCausa;
    }
    /// <summary>
    /// Seleccion de las causas de suicidio ingresados en la base de datos
    /// </summary>
    /// <returns>Lista de todas las causas de suicidos</returns>
    public List<TV_CausaSuicidio> obtenerTodos()
    {
        var bitacora = new bitacoraBomberoaContext();
        var tvCausaSuicidos = bitacora.TV_CausaSuicidio;
        return tvCausaSuicidos.ToList();
    }

    /// <summary>
    /// creación de causa suicidio en la base de datos
    /// </summary>
    public void crear(TV_CausaSuicidio causa)
    {
        var bitacora = new bitacoraBomberoaContext();
        bitacora.TV_CausaSuicidio.Add(causa);
        bitacora.SaveChanges();
    }

    /// <summary>
    /// obtener causa de suicidio en la base de datos por su id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>una sola causa de suicida TV_CausaSuicidio</returns>
    public TV_CausaSuicidio obtener(int id)
    {
        var bitacora = new bitacoraBomberoaContext();
        var tvCausaSuicido = bitacora.TV_CausaSuicidio.Where(s => s.idCausa == id).Single();
        return tvCausaSuicido;
    }

    /// <summary>
    /// modificar la causa de suicidio
    /// </summary>
    /// <param name="causaSuicidio"></param>
    public void modificar(TV_CausaSuicidio causaSuicidio)
    {
        using (var bitacora = new bitacoraBomberoaContext())
        {
            var tvCausaSuicido = bitacora.TV_CausaSuicidio.Find(causaSuicidio.idCausa);
            tvCausaSuicido.CausaSuicidio = causaSuicidio.CausaSuicidio;
            bitacora.SaveChanges();
        }
    }

    internal void eliminar(int id)
    {
        var seleccionado = obtener(id);
        bitacoraBomberoaContext context = new bitacoraBomberoaContext();
        context.TV_CausaSuicidio.Remove(seleccionado);
        context.SaveChanges();
    }
}