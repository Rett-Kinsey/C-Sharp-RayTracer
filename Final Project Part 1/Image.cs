/// <summary>
/// Class <c>Image</c> implemetns a class for maipulating images
/// Author:Rett Kinsey
/// Date:9/19/2023
/// </summary>
using System.Drawing;
using System.Reflection.PortableExecutable;

namespace HW4
{
    public class Image
    {

        private int _width;

        private int _height;

        public double _gamma; 

        public Bitmap _solution;

        /// <summary>
        /// This is the constructor for the Image class with parameters.
        /// </summary>
        /// <param name="_width">The width of the image.</param>
        /// <param name="_height">The height of the image.</param>
        /// <param name="_gamma">The gamma value of the computer.</param>
        public Image(int width = 512 ,int  height = 512 , double gamma = 1.8f){

            _solution = new Bitmap(width, height, System.Drawing. Imaging. PixelFormat. Format32bppPArgb);
            _height = height;
            _width = width;
            _gamma = gamma;
            BackBlack();
            
        }

         /// <summary>
        /// This is the Getter and Setter for the _width variable.
        /// </summary>
        public int Width{
            get {return _width;}
            set {
                _width = value;
                _solution = new Bitmap(_width,_height,System.Drawing. Imaging. PixelFormat. Format32bppPArgb);
                this.BackBlack();
                }
        }

        /// <summary>
        /// This is the Getter and Setter for the _height variable.
        /// </summary>
        public int Height{
            get {return _height;}
            set {
                _height = value;
                _solution = new Bitmap(_width,_height,System.Drawing. Imaging. PixelFormat. Format32bppPArgb);
                this.BackBlack();
                }

        }
        
        /// <summary>
        /// This sets the entire image to black
        /// </summary>
        public void BackBlack(){

            Color black = Color.FromArgb(255,0,0,0);
            
            for (int Xcount = 0; Xcount < this._width; Xcount++)
            {
                for (int Ycount = 0; Ycount < this._height; Ycount++)
                {
                    _solution.SetPixel(Xcount, Ycount, black);
                }
            }
        }

       /// <summary>
        /// This changes the color of a single pixel
        /// </summary>
        /// <param name="i">The iterator for the x value.</param>
        /// <param name="j">The iterator for the y value.</param>
        /// <param name="color">A vector storing the RGB values.</param>
        /// <param name="alpha">The alpha value of the pixel.</param>
        public void Paint(int i,int j,Vector color, int alpha = 255)
        {  
            
            if (i>=0 && i<= _width && j>=0 && j<= _height)
            {
                 _solution.SetPixel(i, _height-j-1, Color.FromArgb(Clamp(0,255,alpha),Clamp(0,255,(int)color.X),Clamp(0,255,(int)color.Y),Clamp(0,255,(int)color.Z)));
            }
        }
        

        /// <summary>
        /// This saves the image in png format.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        public void SaveImage(String fileName){

            double gammaQuotient = 1/_gamma;
            double divisor255 = 1/255.0;


            for (int Xcount = 0; Xcount < this._width; Xcount++)
            {
                for (int Ycount = 0; Ycount < this._height; Ycount++)
                {
                    Color color = _solution.GetPixel(Xcount,Ycount);
                    int newRed = (int)(255*Math.Pow(color.R*divisor255,gammaQuotient));
                    int newGreen = (int)(255*Math.Pow(color.G*divisor255,gammaQuotient));
                    int newBlue = (int)(255*Math.Pow(color.B*divisor255,gammaQuotient));


                    _solution.SetPixel(Xcount, Ycount,Color.FromArgb(color.A,newRed,newGreen,newBlue));
                }
            }
            _solution.Save(fileName);
        }

        public int Clamp(int min, int max, int val){
            
            if (val < min){
                return min;
            } else if (val > max){
                return max;
            } else{
                return val;
            }


        }

    }

}

