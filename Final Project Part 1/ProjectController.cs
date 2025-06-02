// See https://aka.ms/new-console-template for more information


using System.ComponentModel;
using System.IO.Compression;
using System.Security.Principal;

/// <summary>
/// Class <c>Project Controler</c> tests and creates various images for the final project.
/// All ply files from https://people.sc.fsu.edu/~jburkardt/data/ply/teapot.ply
/// Author: Rett Kinsey
/// Date:12/14/2023
/// Time spent: Forgot to keep count, but I think about 20 hours
/// Collaborators: none
/// Feedback: (in the controller only)
/// </summary>
/// 
namespace HW4{

    class HW4Controller{

        static void Main(string[] args)
        {
            

           
            //Setup the camera
            Camera c2 = new Camera(Camera.Projection.Perspective,
            new Vector(0.0f, 20.0f, 90.0f),
            //new Vector(90.0f, 20.0f, -30.0f),
            //new Vector(0.0f, 20.0f, 150.0f),
            new Vector(0.0f, 0f, 0f),
            new Vector(0.0f, 1f, 0f),
            0.1f, 250f, 512, 512, -10f, 10f, -10f, 10f);
            //Build the
            Scene scene = new Scene();
            Shape s = new Sphere(new Vector(0.0f, 10.0f, 50.0f), 20f);
            Shape s2 = new Sphere(new Vector(50.0f, 15.0f, 10.0f), 30f);
            Shape s3 = new Sphere(new Vector(-60f, 30f, -10.0f), 60f);
            s3.D = new Vector(0.0f, 255f, 0.0f);
            s2.D = new Vector(200f, 0.0f, 255f);
            Shape p1 = new Plane(new Vector(50,0,50),new Vector(0,1,0));
            p1.D = new Vector(255,0,20);
            scene.AddShape(ref p1);
            scene.AddShape(ref s3);
            scene.AddShape(ref s2);
            scene.AddShape(ref s);
            scene.Light = new Vector(50.0f,140.0f,-30.0f);
            //.Light = new Vector(0.0f,20.0f,90.0f);
            //scene.Light = new Vector(0.0f,100.0f,70.0f);
            //scene.Light = new Vector(0.0f,100.0f,-90.0f);
            //foreach( Shape shape in scene.AllShapes){
            //    Console.WriteLine(shape.D);
            //}

            c2.RenderImage("SphereScene2.bmp", scene,4);

            //Array
            
            //Setup the camera
            
            /*
            Camera c3 = new Camera(Camera.Projection.Orthographic,
            new Vector(50.0f, 20.0f, 50.0f),
            new Vector(50.0f, 0.0f, 50.0f),
            new Vector(1.0f, 0.0f, 0.0f),
            10.0f, 200.0f, 512, 512, -50f, 50f, -50f, 50f);
            c3.RecurLimit = 5;
            
            //Build the scene 

            Scene scene2 = new Scene();
            scene2.Light = new Vector(50.0f, 60.0f, 50.0f);

            var rand = new Random();
            Shape generic = new Sphere();
            for ( int i = 0; i < 10;i++){
                for ( int j = 0; j < 10;j++){
                    generic = new Sphere(new Vector(5+i*10,0,5+j*10),5);
                    //generic.Centerpoint= new Vector(5+i*10,0,5+j*10);
                    //generic.Radius = 10;
                    generic.D = new Vector(rand.Next(0,255),rand.Next(0,255),rand.Next(0,255));
                    generic.Shiny = (float)rand.NextDouble()*127+1;
                    scene2.AddShape(ref generic);
                }

            }

            c3.RenderImage("SphereArray.bmp", scene2,2);
            */



            
            /*Camera c4 = new Camera(Camera.Projection.Orthographic,
            new Vector(0, .50f, 5f),
            new Vector(0.0f, 0.0f, 0.0f),
            new Vector(0.0f, 1.0f, 0.0f),
            .1f, 200.0f, 512, 512, -2f, 2f, -2f, 2f);

            Scene scene4 = new Scene();
            scene4.Light = new Vector(2f,2f,2f);
            Plyreader ply = new Plyreader("pyramid.txt");
            List<Shape> faces = ply.Faces;
           
            foreach (Shape tri in faces){
                Shape face = tri;
                scene4.AddShape(ref face);
            }
            */

            /*
            Shape face = ply.Faces[2];
            face.D = new Vector(255f,0f,0f);
            scene4.AddShape(ref face);
            Shape face2 = ply.Faces[3];
            face2.D = new Vector(0f,255f,0f);
            scene4.AddShape(ref face2);
            Shape face3 = ply.Faces[4];
            face3.D = new Vector(0f,0f,255f);
            scene4.AddShape(ref face3);
            Shape face4 = ply.Faces[5];
            face4.D = new Vector(200f,200f,200f);
            scene4.AddShape(ref face4);
            */

            //c4.RenderImage("Pyramid2.bmp", scene4,3);
            
           
           
           
           
            /*
            
             Camera c5 = new Camera(Camera.Projection.Orthographic,
            new Vector(0f, 100.0f, 0.0f),
            new Vector(0.0f, 0f, 0f),
            new Vector(1.0f, 0.0f, 0f),
            0.1f, 250f, 512, 512, -10f, 10f, -10f, 10f);

            Scene scene3 = new Scene();
            scene3.Light = new Vector(0.0f, 10.0f, 0.0f);
            Shape myTri = new Triangle(
                
                new Vector(0,0,5),
                new Vector(5,0,-5),
                new Vector(-5,0,-5)
                
                /*
                new Vector(0,0,5),
                new Vector(-5,0,-5),
                new Vector(5,0,-5)
                *//*
                );
                myTri.S = new Vector(150,150,150);
                
            scene3.AddShape(ref myTri);
            myTri.D = new Vector(0,80,255);

            c5.RenderImage("Triangle1.bmp", scene3,2);
            */

            //Teapot
             
            /*
             Camera c6= new Camera(Camera.Projection.Orthographic,
            new Vector(0f, 50.0f, 0.0f),
            new Vector(0.0f, 0f, 0f),
            new Vector(0.0f, 0.0f, 1f),
            0.1f, 250f, 512, 512, -5f, 5f, -5f, 5f);

             Scene scene5 = new Scene();
            scene5.Light = new Vector(0f,100f,0f);
            Plyreader ply1 = new Plyreader("teapot.txt");
            List<Shape> faces1 = ply1.Faces;
           
            Vector blueSky = new Vector(0,80,250);
            foreach (Shape tri in faces1){
                Shape face = tri;
                face.D = blueSky;
                scene5.AddShape(ref face);
            }

            c6.RenderImage("teapot2.bmp",scene5,2);
            */
            
        /*
            Camera c9= new Camera(Camera.Projection.Orthographic,
            new Vector(0f, 50.0f, 0.0f),
            new Vector(0.0f, 0f, 0f),
            new Vector(0.0f, 0.0f, 1f),
            0.1f, 250f, 512, 512, -5f, 5f, -5f, 5f);

             Scene scene9 = new Scene();
            scene9.Light = new Vector(0f,20f,0f);
            Plyreader ply9 = new Plyreader("Shark.ply");
            List<Shape> faces9 = ply9.Faces;
           
            Vector blueWater = new Vector(0,60,200);
            Vector blueShark = new Vector(50,50,150);
            foreach (Shape tri in faces9){
                Shape face = tri;
                face.D = blueShark;
                scene9.AddShape(ref face);
            }
            Shape seaBack = new Plane(new Vector(0,0,0),new Vector(0,1,0));
            seaBack.D = blueWater;
            seaBack.S = new Vector(200,200,200);
            scene9.AddShape(ref seaBack);
            

            c9.RenderImage("shark2.bmp",scene9,2);

            */

            /*
            Camera c7= new Camera(Camera.Projection.Orthographic,
            new Vector(0f, 50.0f, 0.0f),
            new Vector(0.0f, 0f, 0f),
            new Vector(0.0f, 0.0f, 1f),
            0.1f, 250f, 512, 512, -5f, 5f, -5f, 5f);

            Shape sphere = new Sphere(new Vector(0,0,0), 4.5f);
            Scene scene7 = new Scene();
            scene7.Light = new Vector(20,30,0);
            scene7.AddShape(ref sphere);
             

            c7.RenderImage("sphere10.bmp",scene7,10);
           */
        }
    }
}
