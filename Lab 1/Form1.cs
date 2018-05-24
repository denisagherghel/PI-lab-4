using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab_1
{
    public partial class Form1 : Form
    { 
        Bitmap InitialImage, TransformedImage;
        List<Color> conturP;
        private Image loadedImage;
       
        public Form1()
        {
            InitializeComponent();
            
            saveFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            saveFileDialog.DefaultExt = "png";

            conturP = new List<Color>();
        }

        private bool isLocalMaximum(int[,] mat, int i, int j)
        {
            return (mat[i - 1, j - 1] <= mat[i, j])
                && (mat[i - 1, j] <= mat[i, j])
                && (mat[i - 1, j + 1] <= mat[i, j])
                && (mat[i, j - 1] <= mat[i, j])
                && (mat[i, j + 1] <= mat[i, j])
                && (mat[i + 1, j - 1] <= mat[i, j])
                && (mat[i + 1, j] <= mat[i, j])
                && (mat[i + 1, j + 1] <= mat[i, j]);
        }

        public void scheletizare(Bitmap image)
        {
            Bitmap contour = (Bitmap)image.Clone();
            int[,] distances = new int[image.Height, image.Width];
            int i, j, vi, vj, k;
            int max_dist = Math.Max(image.Width, image.Height);
            int contour_color = 0;
            List<Tuple<int, int>> current_distance = new List<Tuple<int, int>>();
            bool modified = true;

            contur(contour);

            for (i = 0; i < contour.Height; i++)
            {
                for (j = 0; j < contour.Width; j++)
                {
                    if (contour.GetPixel(j, i).R == contour_color)
                    {
                        distances[i, j] = 0;
                        current_distance.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        distances[i, j] = max_dist;
                    }
                }
            }

            while (modified)
            {
                modified = false;
                for (i = 0; i < image.Height; i++)
                {
                    for (j = 0; j < image.Width; j++)
                    {
                        k = distances[i, j];
                        for (vi = Math.Max(0, i - 1); vi <= Math.Min(image.Height - 1, i + 1); vi++)
                        {
                            for (vj = Math.Max(0, j - 1); vj <= Math.Min(image.Width - 1, j + 1); vj++)
                            {
                                k = Math.Min(k, distances[vi, vj] + 1);
                            }
                        }
                        if (distances[i, j] != k)
                        {
                            modified = true;
                            distances[i, j] = k;
                        }
                    }
                }
            }

            for (i = 0; i < contour.Height; i++)
            {
                contour.SetPixel(0, i, Color.FromArgb(255, 255, 255));
                contour.SetPixel(contour.Width - 1, i, Color.FromArgb(255, 255, 255));
            }
            for (j = 0; j < contour.Width; j++)
            {
                contour.SetPixel(j, 0, Color.FromArgb(255, 255, 255));
                contour.SetPixel(j, contour.Height - 1, Color.FromArgb(255, 255, 255));
            }

            for (i = 1; i < image.Height - 1; i++)
            {
                for (j = 1; j < image.Width - 1; j++)
                {
                    int color;
                    color = (image.GetPixel(j, i).R == 0 && isLocalMaximum(distances, i, j)) ? 0 : 255; //Is local maximum and inside object
                    //color = Math.Max( 0, 255 - distances1[ i, j ] * 16 );
                    //image.SetPixel( j, i, Color.FromArgb( 255 - distances[ i, j ], 255 - distances[ i, j ], 255 - distances[ i, j ] ) );
                    image.SetPixel(j, i, Color.FromArgb(color, color, color));
                }
            }

            TransformedImage = image;

            transformedPictureBox.Image = TransformedImage;
        }

        private bool is_in_bounds(int val, int ll, int ul)
        {
            return (val >= ll && val < ul);
        }

        public void contur(Bitmap image)
        {
            Bitmap contour = new Bitmap(image.Width, image.Height);
            int bg_color = 255;
            int neighbour_size = 1;
            bool[,] neighbour_mask = { { false, true, false }, { true, false, true }, { false, true, false } };
            int i, j, ni, nj;
            bool is_contour;
            int req_center_color = 0;
            Color pixel;
            for (i = 0; i < image.Height; i++)
            {
                for (j = 0; j < image.Width; j++)
                {
                    is_contour = false;
                    pixel = image.GetPixel(j, i);
                    if (pixel.R == req_center_color)
                    {
                        for (ni = -neighbour_size; ni <= neighbour_size && !is_contour; ni++)
                        {
                            for (nj = -neighbour_size; nj <= neighbour_size && !is_contour; nj++)
                            {
                                if (!neighbour_mask[ni + neighbour_size, nj + neighbour_size])
                                    continue;
                                pixel = (is_in_bounds(i + ni, 0, image.Height) && is_in_bounds(j + nj, 0, image.Width)) ? image.GetPixel(j + nj, i + ni) : Color.FromArgb(bg_color, bg_color, bg_color);
                                if (pixel.R != req_center_color)
                                {
                                    is_contour = true;
                                }
                            }
                        }
                    }
                    if (is_contour)
                    {
                        contour.SetPixel(j, i, Color.Black);
                    }
                    else
                    {
                        contour.SetPixel(j, i, Color.White);

                    }
                }
            }
            for (i = 0; i < image.Height; i++)
            {
                for (j = 0; j < image.Width; j++)
                {
                    image.SetPixel(j, i, contour.GetPixel(j, i));
                }
            }

            transformedPictureBox.Image = contour;
        }

        public static List<List<Tuple<int, int>>> get_contour_description(Bitmap image)
        {
            List<List<Tuple<int, int>>> descr = new List<List<Tuple<int, int>>>();
            int i, j;
            int pozx, pozy;
            int contour_color = 0;
            Color pixel;
            Stack<Tuple<int, int>> to_visit = new Stack<Tuple<int, int>>();
            Bitmap imageCopy = (Bitmap)image.Clone();
            for (i = 0; i < imageCopy.Height; i++)
            {
                for (j = 0; j < imageCopy.Width; j++)
                {
                    pixel = imageCopy.GetPixel(j, i);
                    if (pixel.R == contour_color)
                    {
                        List<Tuple<int, int>> contour = new List<Tuple<int, int>>();
                        to_visit.Push(new Tuple<int, int>(j, i));
                        imageCopy.SetPixel(j, i, Color.FromArgb(255 - contour_color, 255 - contour_color, 255 - contour_color));

                        while (to_visit.Count > 0)
                        {
                            pozx = to_visit.Peek().Item1;
                            pozy = to_visit.Peek().Item2;
                            contour.Add(to_visit.Pop());
                            for (int y = Math.Max(0, pozy - 1); y <= Math.Min(pozy + 1, imageCopy.Height - 1); y++)
                            {
                                for (int x = Math.Max(0, pozx - 1); x <= Math.Min(pozx + 1, imageCopy.Width - 1); x++)
                                {
                                    pixel = imageCopy.GetPixel(x, y);
                                    if (pixel.R == contour_color)
                                    {
                                        to_visit.Push(new Tuple<int, int>(x, y));
                                        imageCopy.SetPixel(x, y, Color.FromArgb(255 - contour_color, 255 - contour_color, 255 - contour_color));
                                    }
                                }
                            }
                        }
                        descr.Add(contour);
                    }
                }
            }

            return descr;
        }

        private void subtiere()
        {
            bool[,] toDelete = new bool[InitialImage.Width, InitialImage.Height];
            bool changes = true;
            int steps = 0;
            int s = 0;
            TransformedImage = new Bitmap(InitialImage);

            Color color = (Color)ColorTranslator.FromHtml("#ffffff");

            while (changes && steps < 50)
            {
                changes = false; int deleted = 0;
                steps++;
                for (int i = 1; i < InitialImage.Width - 1; i++)
                {
                    for (int j = 1; j < InitialImage.Height - 1; j++)
                    {
                        s = 0;
                        if (TransformedImage.GetPixel(i - 1, j - 1) != color) s++;
                        if (TransformedImage.GetPixel(i - 1, j) != color) s++;
                        if (TransformedImage.GetPixel(i - 1, j + 1) != color) s++;
                        if (TransformedImage.GetPixel(i, j - 1) != color) s++;
                        if (TransformedImage.GetPixel(i, j + 1) != color) s++;
                        if (TransformedImage.GetPixel(i + 1, j - 1) != color) s++;
                        if (TransformedImage.GetPixel(i + 1, j ) != color) s++;
                        if (TransformedImage.GetPixel(i + 1, j + 1) != color) s++;
                       
                        if(2 <= s && s <= 6)
                        {
                            toDelete[i, j] = true;
                            deleted++;
                        } else
                        {
                            toDelete[i, j] = false;
                        }
                    }
                }

                for (int i = 1; i < InitialImage.Width - 1; i++)
                {
                    for (int j = 1; j < InitialImage.Height - 1; j++)
                    {
                        if(toDelete[i,j] == true)
                        {
                            TransformedImage.SetPixel(i, j, Color.White);
                            changes = true;
                        }
                    }
                }

                deleted = deleted;
            }

            transformedPictureBox.Image = TransformedImage;
        }

        private bool isInBounds(int val, int ll, int ul)
        {
            return (val >= ll && val < ul);
        }

        public void subtiere(Bitmap image)
        {
            //Bitmap contour = ( Bitmap )image.Clone();
            int i, j, vi, vj, nv, nt;
            int object_color = 0;
            Tuple<int, int>[] neighbours = { new Tuple<int, int>( -1, 1 ), new Tuple<int, int>( -1, 0 ), new Tuple<int, int>( -1, -1 ),
                                             new Tuple<int, int>( 0, -1 ), new Tuple<int, int>( 1, -1 ), new Tuple<int, int>( 1, 0 ),
                                             new Tuple<int, int>( 1, 1 ), new Tuple<int, int>( 0, 1 ) };
            List<Tuple<int, int>> to_remove = new List<Tuple<int, int>>();
            bool modified = true;
            Color pixel;
            int color;
            int other_color;
            //new Contour().apply( contour );

            while (modified)
            {
                modified = false;
                for (i = 0; i < image.Height; i++)
                {
                    for (j = 0; j < image.Width; j++)
                    {
                        pixel = image.GetPixel(j, i);
                        if (pixel.R == object_color)
                        {
                            nv = 0;
                            nt = 0;
                            for (int k = 0; k < neighbours.Length; k++)
                            {
                                vi = i + neighbours[k].Item1;
                                vj = j + neighbours[k].Item2;
                                if ((isInBounds(vi, 0, image.Height)) && isInBounds(vj, 0, image.Width) && image.GetPixel(vj, vi).R == object_color)
                                {
                                    nv++;
                                }
                            }
                            for (int k = 0; k < neighbours.Length; k++)
                            {
                                vi = i + neighbours[k].Item1;
                                vj = j + neighbours[k].Item2;
                                color = (isInBounds(vi, 0, image.Height) && isInBounds(vj, 0, image.Width)) ? image.GetPixel(vj, vi).R : 255 - object_color;

                                vi = i + neighbours[(k + 1) % neighbours.Length].Item1;
                                vj = j + neighbours[(k + 1) % neighbours.Length].Item2;
                                other_color = (isInBounds(vi, 0, image.Height) && isInBounds(vj, 0, image.Width)) ? image.GetPixel(vj, vi).R : 255 - object_color;

                                nt += (color != other_color) ? 1 : 0;
                            }
                            if (2 <= nv && nv <= 6 && nt == 2)
                            {
                                to_remove.Add(new Tuple<int, int>(j, i));
                                //image.SetPixel( j,i, Color.FromArgb( 255 - object_color, 255 - object_color, 255 - object_color ) );
                                modified = true;
                            }
                        }
                    }
                }

                foreach (var p in to_remove)
                {
                    image.SetPixel(p.Item1, p.Item2, Color.FromArgb(255 - object_color, 255 - object_color, 255 - object_color));
                }
                to_remove.Clear();
            }
        

            transformedPictureBox.Image = image;
        }

        private void makeInitial()
        {
            InitialImage = TransformedImage;
            initialPictureBox.Image = InitialImage;
            initialPictureBox.Refresh();
            transformedPictureBox.Image = null;
            transformedPictureBox.Refresh();
        }

        private void openImage()
        {
            openFileDialog.ShowDialog();
            loadedImage = Image.FromFile(openFileDialog.FileName);
            InitialImage = new Bitmap(loadedImage);
            initialPictureBox.Image = InitialImage;
            initialPictureBox.Refresh();
        }

        

        private void saveImage()
        {
            saveFileDialog.ShowDialog();
            TransformedImage.Save(saveFileDialog.FileName);
        }

        private void buttonOpenImage_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void buttonDeterminareContur_Click(object sender, EventArgs e)
        {
            Bitmap toTransform = new Bitmap(InitialImage);
            contur(toTransform);
        }

        private void buttonDeterminareSchelet_Click(object sender, EventArgs e)
        {
            Bitmap toTransform = new Bitmap(InitialImage);
            scheletizare(toTransform);
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void buttonSubtiere_Click(object sender, EventArgs e)
        {
            Bitmap toTransform = new Bitmap(InitialImage);
            subtiere(toTransform);
        }

        private void buttonMakeInitial_Click(object sender, EventArgs e)
        {
            makeInitial();
        }
        
    }
}
