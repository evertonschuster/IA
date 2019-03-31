using System;
using OpenCvSharp;

namespace OpenCVSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var detectedFaceGrayImage = new Mat();
            var grayImage = new Mat();
            var srcImage = new Mat(@"..\..\Images\Test.jpg");
            var cascade = new CascadeClassifier(@"..\..\Data\haarcascade_frontalface_alt.xml");
            var nestedCascade = new CascadeClassifier(@"..\..\Data\haarcascade_eye_tree_eyeglasses.xml");

            VideoCapture video = new VideoCapture(0);

            for (int i = 0; i < 1000; i++)
            {
                video.Read(srcImage);

                Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGRA2GRAY);
                Cv2.EqualizeHist(grayImage, grayImage);

                var faces = cascade.DetectMultiScale(
                    image: grayImage,
                    scaleFactor: 1.1,
                    minNeighbors: 2,
                    flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                    minSize: new Size(30, 30)
                    );

                foreach (var faceRect in faces)
                {
                    var detectedFaceImage = new Mat(srcImage, faceRect);
                    Cv2.Rectangle(srcImage, faceRect, Scalar.Red, 2);

                    Cv2.CvtColor(detectedFaceImage, detectedFaceGrayImage, ColorConversionCodes.BGRA2GRAY);
                    var nestedObjects = nestedCascade.DetectMultiScale(
                        image: grayImage,
                        scaleFactor: 1.1,
                        minNeighbors: 2,
                        flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                        minSize: new Size(30, 30)
                        );

                    foreach (var nestedObject in nestedObjects)
                    {
                        Cv2.Rectangle(srcImage, nestedObject, Scalar.YellowGreen, 2);
                    }
                }

                Cv2.ImShow("tela", srcImage);
                Cv2.WaitKey(1); // do events

            }

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
            srcImage.Dispose();
        }
    }
}