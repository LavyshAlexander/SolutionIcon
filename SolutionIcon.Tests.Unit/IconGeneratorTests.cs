﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using SolutionIcon.Implementation;
using SolutionIcon.Tests.Unit.Helpers;
using Xunit;
using Xunit.Extensions;

namespace SolutionIcon.Tests.Unit {
    public class IconGeneratorTests {
        [Theory]
        [InlineData("SolutionIcon", "SolutionIconPath")]
        [InlineData("Magic", "MagicPath")]
        [InlineData("o_O", "o_O")]
        [InlineData("术", "术")]
        [InlineData("♪", "♪")]
        public void GenerateIcon_ReturnsExpectedImage(string solutionName, string solutionPath) {
            var actualPath = ResolveTestPath(solutionName + ".actual.png");
            var generator = new IconGenerator(new TinyIdGenerator());
            using (var image = generator.GenerateIcon(solutionName, solutionPath, new Size(32, 32))) {
                image.Save(actualPath, ImageFormat.Png);
            }

            AssertImages.Equal(ResolveTestPath(solutionName + ".expected.png"), actualPath);
        }

        private static string ResolveTestPath(string fileName) {
            return TestPathResolver.Resolve(Path.Combine("TestFiles", "IconGenerator", fileName));
        }
    }
}
