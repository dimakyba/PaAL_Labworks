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
}

func (g *Game) Update() error {
	return nil
}

func (g *Game) Draw(screen *ebiten.Image) {

	// vector.DrawFilledCircle(screen, centerX, centerY, float32(dotRadius), color.White, true)

	drawHalfCircle(screen, 200, 100, 50)

	points := []struct{ x, y float32 }{
		{450, 200},
		{550, 250},
		{500, 350},
		{400, 300},
	}
	drawPolygon(screen, points)

	// drawFilledPie(screen, 575, 15, 200, 180, 90, color.RGBA{0, 255, 255, 255})
	var pieCenterX float32 = 400
	var pieCenterY float32 = 400
	var radius float32 = 45

	for i := 0.; i < 4; i += 0.005 {

		vector.StrokeLine(screen, pieCenterX, pieCenterY, pieCenterX+radius*float32(math.Cos(float64(i))), pieCenterY+radius*float32(math.Sin(float64(i))), float32(1), color.RGBA{255, 255, 0, 0}, true)
	}
	// ebitenutil.DrawLine()

}

func drawHalfCircle(screen *ebiten.Image, cx, cy, radius int) {
	const segments = 100 // Number of segments to approximate the half-circle
	angleStep := math.Pi / float64(segments)

	for i := 0; i < segments; i++ {
		theta1 := float64(i) * angleStep
		theta2 := float64(i+1) * angleStep

		x1 := float64(cx) + float64(radius)*math.Cos(theta1)
		y1 := float64(cy) + float64(radius)*math.Sin(theta1)
		x2 := float64(cx) + float64(radius)*math.Cos(theta2)
		y2 := float64(cy) + float64(radius)*math.Sin(theta2)

		// ebitenutil.DrawLine(screen, x1, y1, x2, y2, color.White)

		vector.StrokeLine(screen, float32(x1), float32(y1), float32(x2), float32(y2), float32(2), color.White, true)
	}
}

func drawPolygon(screen *ebiten.Image, points []struct{ x, y float32 }) {
	n := len(points)
	if n < 2 {
		return
	}

	for i := 0; i < n; i++ {
		p1 := points[i]
		p2 := points[(i+1)%n] // to wrap around to the first point
		vector.StrokeLine(screen, p1.x, p1.y, p2.x, p2.y, 2, color.RGBA{0, 255, 0, 0}, true)
	}
}

func (g *Game) Layout(outsideWidth, outsideHeight int) (int, int) {
	return screenWidth, screenHeight
}

func main() {
	game := &Game{}
	ebiten.SetWindowSize(screenWidth, screenHeight)
	ebiten.SetWindowTitle("Shapes")

	if err := ebiten.RunGame(game); err != nil {
		log.Fatal(err)
	}
}
