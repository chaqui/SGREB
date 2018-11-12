using System;
using System.Globalization;
using System.Windows.Forms;

namespace SGREB.miscellany
{
    class Cronometro
    {
        private Timer Tiempo;
        public Double segundos { get; set; }

        public Cronometro()
        {
            Tiempo = new Timer();
            Tiempo.Tick += new EventHandler(Tiempo_Tick);
            Tiempo.Interval = 100;
        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            segundos++;
        }
        public void stop()
        {
            Tiempo.Stop();
        }
         
        public void start()
        {
            Tiempo.Start();
        }
    }

}
