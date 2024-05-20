package main

import (
	"image/color"
	"log"
	"math"

	"github.com/hajimehoshi/ebiten/v2"
	"github.com/hajimehoshi/ebiten/v2/vector"
)

const (
	screenWidth   = 640
	screenHeight  = 480
	dotRadius     = 5
	centerX       = screenWidth / 2
	centerY       = screenHeight / 2
	orbitRadius_1 = 75
	orbitRadius_2 = 100
)

type Game struct {
	angle float64
}

func (g *Game) Update() error {
	g.angle += 0.05
	return nil
}

func (g *Game) Draw(screen *ebiten.Image) {

	vector.DrawFilledCircle(screen, centerX, centerY, float32(dotRadius), color.White, true)

	x_1 := centerX + orbitRadius_1*math.Cos(g.angle)
	y_1 := centerY + orbitRadius_1*math.Sin(g.angle)

	x_2 := centerX + orbitRadius_2*math.Cos(-g.angle)
	y_2 := centerY + orbitRadius_2*math.Sin(-g.angle)

	vector.DrawFilledCircle(screen, float32(x_1), float32(y_1), float32(dotRadius), color.RGBA{0, 0, 255, 0}, true)
	vector.DrawFilledCircle(screen, float32(x_2), float32(y_2), float32(dotRadius), color.RGBA{255, 255, 0, 0}, true)
}

func (g *Game) Layout(outsideWidth, outsideHeight int) (int, int) {
	return screenWidth, screenHeight
}

func main() {
	game := &Game{}
	ebiten.SetWindowSize(screenWidth, screenHeight)
	ebiten.SetWindowTitle("Spinning Dot")

	if err := ebiten.RunGame(game); err != nil {
		log.Fatal(err)
	}
}
