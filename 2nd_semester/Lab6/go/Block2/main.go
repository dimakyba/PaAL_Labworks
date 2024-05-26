package main

import (
	"image"
	"image/color"
	"log"
	"math"

	"github.com/hajimehoshi/ebiten/v2"
	"github.com/hajimehoshi/ebiten/v2/vector"
)

type Game struct{}

func (g *Game) Update() error {
	return nil
}

func (g *Game) Draw(screen *ebiten.Image) {
	var pieCenterX float32 = 320
	var pieCenterY float32 = 240
	var radius float32 = 150

	for i := 0.; i < 8; i += 0.005 {

		vector.StrokeLine(screen, pieCenterX, pieCenterY, pieCenterX+radius*float32(math.Cos(float64(i)))/2, pieCenterY+radius*float32(math.Sin(float64(i)))/4, float32(0.5), color.RGBA{255, 255, 255, 0}, false)
	}

	vector.DrawFilledCircle(screen, 280., 225., 10., color.Black, true)
}

type Image struct {
	// contains filtered or unexported fields
}

func (i *Image) Bounds() image.Rectangle {

}

func (g *Game) Layout(outsideWidth, outsideHeight int) (screenWidth, screenHeight int) {
	return 640, 480
}

func main() {
	ebiten.SetWindowSize(640, 480)
	ebiten.SetWindowTitle("Hello, World!")
	if err := ebiten.RunGame(&Game{}); err != nil {
		log.Fatal(err)
	}
}
