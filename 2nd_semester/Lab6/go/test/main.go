package main

import (
	"github.com/fogleman/gg"
)

func main() {
	const (
		width  = 600
		height = 400
	)

	// Create a new image context
	dc := gg.NewContext(width, height)

	// Set background color
	dc.SetRGB(0.8, 0.9, 1)
	dc.Clear()

	// Set pen color
	dc.SetRGB(0.5, 0.5, 0.5)

	// Set line width
	dc.SetLineWidth(3)

	// Draw body
	bodyWidth := 200.0
	bodyHeight := 100.0
	dc.DrawEllipse(width/2, height/2, bodyWidth, bodyHeight)
	dc.Fill()

	// Draw tail
	tailSize := 50.0
	tailHeight := 60.0
	dc.MoveTo(width/2-bodyWidth/2-tailSize/2, height/2)
	dc.LineTo(width/2-bodyWidth/2-tailSize/2, height/2-tailHeight/2)
	dc.LineTo(width/2-bodyWidth/2-tailSize, height/2)
	dc.LineTo(width/2-bodyWidth/2-tailSize/2, height/2+tailHeight/2)
	dc.LineTo(width/2-bodyWidth/2-tailSize/2, height/2)
	dc.ClosePath()
	dc.Fill()

	// Draw eye
	eyeSize := 10.0
	dc.SetRGB(0, 0, 0)
	dc.DrawEllipse(width/2+bodyWidth/4, height/2-bodyHeight/4, eyeSize, eyeSize)
	dc.Fill()

	// Save the drawing to a file
	dc.SavePNG("fish.png")
}
