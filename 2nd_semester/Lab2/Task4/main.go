package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	fmt.Println("Labwork #7")
	fmt.Println("Task #4, Variant #13")
	fmt.Println("Упорядкувати стовпчики матриці за незростанням кількостей нулів у цих стовпчиках (тобто, зліва стовпчики, де нулів найбільше, потім ті де трохи менше, і так аж до правого краю, де ті стовпчики, в яких нулів найменше).\n")

	var rows, cols int
	fmt.Print("Введіть кількість рядків матриці: ")
	fmt.Scanln(&rows)
	fmt.Print("Введіть кількість стовбчиків матриці: ")
	fmt.Scanln(&cols)

	var matrix [][]int

	fmt.Println("Виберіть як ви хочете ввести масив:")
	fmt.Println("1. Вручну")
	fmt.Println("2. Автоматично, псевдо-випадковими числами")

	var choiceOfInput int
	fmt.Scanln(&choiceOfInput)

	switch choiceOfInput {
	case 1:
		matrix = generateMatrixFromUserInput(rows, cols)
	case 2:
		matrix = generateRandomSquareMatrix(rows, cols)
	default:
		fmt.Println("Invalid choice.")
		return
	}

	if matrix != nil {
		printMatrix(matrix)
		matrix = sortColsOfMatrixDescendingZeros(matrix)
		printMatrix(matrix)
	}
}

func printMatrix(matrix [][]int) {
	for _, row := range matrix {
		fmt.Print("(")
		for _, val := range row {
			fmt.Printf("%4d ", val)
		}
		fmt.Println(")")
	}
}

func generateRandomSquareMatrix(rows, cols int) [][]int {
	matrix := make([][]int, rows)
	rand.Seed(time.Now().UnixNano())

	for i := range matrix {
		matrix[i] = make([]int, cols)
		for j := range matrix[i] {
			matrix[i][j] = rand.Intn(2)
		}
	}

	return matrix
}

func generateMatrixFromUserInput(rows, cols int) [][]int {
	matrix := make([][]int, rows)

	for i := range matrix {
		matrix[i] = make([]int, cols)
		for j := range matrix[i] {
			fmt.Printf("Введіть [%d,%d]: ", i+1, j+1)
			fmt.Scanln(&matrix[i][j])
		}
	}

	return matrix
}

func sortColsOfMatrixDescendingZeros(matrix [][]int) [][]int {
	fmt.Println("\nСортую стовпчики матриці за незростанням кількостей нулів у цих стовпчиках:")

	zerosInCols := make([]int, len(matrix[0]))

	for j := range matrix[0] {
		count := 0
		for i := range matrix {
			if matrix[i][j] == 0 {
				count++
			}
		}
		zerosInCols[j] = count
	}

	columnIndices := make([]int, len(matrix[0]))
	for i := range columnIndices {
		columnIndices[i] = i
	}

	for i := 1; i < len(matrix[0]); i++ {
		zeroCountTemp := zerosInCols[i]
		columnIndexTemp := columnIndices[i]
		j := i - 1
		for j >= 0 && zerosInCols[j] < zeroCountTemp {
			zerosInCols[j+1] = zerosInCols[j]
			columnIndices[j+1] = columnIndices[j]
			j--
		}
		zerosInCols[j+1] = zeroCountTemp
		columnIndices[j+1] = columnIndexTemp
	}

	sortedMatrix := make([][]int, len(matrix))
	for i := range sortedMatrix {
		sortedMatrix[i] = make([]int, len(matrix[0]))
	}

	for i := range matrix {
		for j := range matrix[i] {
			columnIndex := columnIndices[j]
			sortedMatrix[i][j] = matrix[i][columnIndex]
		}
	}

	return sortedMatrix
}
