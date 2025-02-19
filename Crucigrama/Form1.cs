namespace Crucigrama
{
    public partial class Form1 : Form
    {
        public List<Palabra> palabras = new List<Palabra>();
        public int correctas;
        public Boolean turno = true;
        public Jugador j1, j2;
        int segundos = 0;
        public Form1(Jugador jug1, Jugador jug2)
        {
            this.j1 = jug1;
            this.j2 = jug2;
            InitializeComponent();
            this.correctas = 0;
            this.crearPalabras();
            this.configurarEvento();
            this.escribirCorrectas();
        }

        public void configurarEvento()
        {
            foreach (Control c in panel_contenedor.Controls)
            {
                if (c is TextBox)
                {
                    c.TextChanged += new EventHandler(textboxes_TextChanged);
                }
            }
        }

        public void crearPalabras()
        {
            this.palabras.Add(new Palabra("rana", new List<TextBox> { txt1, txt2, txt3, txt4 }));
            this.palabras.Add(new Palabra("aguila", new List<TextBox> { txt2, txt5, txt6, txt7, txt8, txt9 }));
            this.palabras.Add(new Palabra("buitre", new List<TextBox> { txt10, txt6, txt11, txt12, txt13, txt14 }));
        }


        public void escribirCorrectas()
        {
            lbl_correctas.Text = this.correctas.ToString();
            if (this.turno)
            {
                lbl_turno.Text = j1.nombre;
            }
            else
            {
                lbl_turno.Text = j2.nombre;
            }
        }
        public void analizar()
        {
            foreach (Palabra palabra in palabras)
            {
                if (palabra.estaLlenaCorrectamente() && palabra.llena == false)
                {
                    palabra.llena = true;
                    this.correctas++;
                    this.turno = !this.turno;
                }
            }
            this.escribirCorrectas();
        }

        void textboxes_TextChanged(object sender, EventArgs e)
        {
            int anterior = this.correctas;
            this.analizar();
            if (this.correctas != anterior)
            {
                MessageBox.Show("completado");
            }
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.segundos++;
            lbl_tiempo.Text = this.segundos.ToString();
        }
    }
}