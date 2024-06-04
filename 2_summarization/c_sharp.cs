        public ImageResizeResult ResizeToMaxSize(byte[] bytes, int maxHeight, int maxWidth)
        {
            using (var stream = new MemoryStream(bytes))
            {
               return ResizeImageWithFixedDimensions(stream, size =>
                {
                    var imageSize = new ImageSize
                    {
                        Height = size.Height,
                        Width = size.Width
                    };

                    if ((size.Width > maxWidth) || size.Height > maxHeight)
                    {
                        if (size.Height > size.Width) //Portait
                        {
                            var ratio = CalculateRatio(size.Height, maxHeight);

                            imageSize.Height = maxHeight;
                            imageSize.Width = CalculateNewSize(ratio, imageSize.Width); //  ratio * imageSize.Width;
                        }

                        if (size.Width > size.Height) //Landscape
                        {
                            var ratio = CalculateRatio(size.Width, maxWidth);
                            imageSize.Height = CalculateNewSize(ratio, size.Height); //ratio * size.Height;
                            imageSize.Width = maxWidth;
                        }

                        if (size.Width == size.Height) //Perfect Square
                        {
                            var ratio = CalculateRatio(size.Width, maxWidth);

                            imageSize.Height = CalculateNewSize(ratio, size.Height); // ratio * size.Height;
                            imageSize.Width = CalculateNewSize(ratio, size.Width); //ratio * size.Width;
                        }
                    }

                    return imageSize;
                });
            }
        }