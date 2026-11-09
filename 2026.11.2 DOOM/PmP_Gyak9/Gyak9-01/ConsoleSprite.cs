// 9. labor, The Console Slayer: egy kirajzolható karakter a színeivel (sprite)
namespace ConsoleSlayer
{
    internal class ConsoleSprite
    {
        private ConsoleColor background;
        private ConsoleColor foreground;
        private char glyph;

        // A színek a beépített ConsoleColor felsorolt típus értékei (7. labor), pl. ConsoleColor.Green.
        public ConsoleSprite(ConsoleColor background, ConsoleColor foreground, char glyph)
        {
            this.background = background;
            this.foreground = foreground;
            this.glyph = glyph;
        }

        // Mindhárom csak lekérdezhető: egy sprite a létrehozása után nem változik.
        // Ha egy elemnek más kinézet kell (pl. kinyílt ajtó), új sprite-ot kap.
        public ConsoleColor Background
        {
            get { return background; }
        }

        public ConsoleColor Foreground
        {
            get { return foreground; }
        }

        public char Glyph
        {
            get { return glyph; }
        }
    }
}
