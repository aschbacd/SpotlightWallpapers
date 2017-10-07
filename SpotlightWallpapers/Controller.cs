using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpotlightWallpapers
{
    class Controller
    {
        private string source = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
        private double screenWidth;
        private double screenHeight;

        public Controller()
        {
            screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        public bool CheckIfPathExists(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }

        public bool FileHandler(string destination, bool portraitWallpapers)
        {
            try
            {
                for (int i = 0; Directory.GetFiles(source).Count() > i; i++)
                {
                    // split filename
                    string[] pathArr = Directory.GetFiles(source)[i].Split('\\');
                    string fileName = pathArr.Last();

                    // file naming
                    string sourceFile = System.IO.Path.Combine(source, fileName);
                    string destFile = System.IO.Path.Combine(destination, fileName + ".jpg");

                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(sourceFile);

                        // portrait wallpapers
                        if (portraitWallpapers)
                        {
                            if (img.Width == screenHeight && img.Height == screenWidth)
                            {
                                if (!System.IO.File.Exists(destFile))
                                {
                                    System.IO.File.Copy(sourceFile, destFile, true);
                                }
                            }
                        }

                        // landscape wallpapers
                        if (img.Width == screenWidth && img.Height == screenHeight)
                        {
                            if (!System.IO.File.Exists(destFile))
                            {
                                System.IO.File.Copy(sourceFile, destFile, true);
                            }
                        }
                    }
                    catch { }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
