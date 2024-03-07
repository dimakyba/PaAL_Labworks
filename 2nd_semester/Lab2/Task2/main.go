package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	fmt.Println("Labwork #7")
	fmt.Println("Task #2, Variant #13")
	fmt.Println("Якщо хоча б один з максимальних елементів матриці лежить на головній діагоналі, то перенести його (елемент) на побічну діагоналі симетрично відносно вертикалі; якщо таких елементів кілька, то перенести їх усі; вважати, що матриця гарантовано квадратна.\n")

	var size uint
	fmt.Print("Введіть розмір матриці (n x n): ")
	fmt.Scan(&size)

	fmt.Println("Виберіть як ви хочете ввести масив:")
	fmt.Println("1. Вручну")
	fmt.Println("2. Автоматично, псевдо-випадковими числами")

	var choiceOfInput int8
	fmt.Scan(&choiceOfInput)

	var matrix [][]int

	switch choiceOfInput {
	case 1:
		matrix = generateMatrixFromUserInput(size)
	case 2:
		matrix = generateRandomSquareMatrix(size)
	default:
		fmt.Println("Invalid choice.")
		return
	}

	if matrix != nil {
		printSquareMatrix(matrix)
		moveMaxElementsToSecondaryDiagonal(matrix)
		printSquareMatrix(matrix)
	}
}

func generateRandomSquareMatrix(size uint) [][]int {
	matrix := make([][]int, size)
	rand.Seed(time.Now().UnixNano())

	for i := range matrix {
		matrix[i] = make([]int, size)
		for j := range matrix[i] {
			matrix[i][j] = rand.Intn(199) - 99
		}
	}

	return matrix
}

func generateMatrixFromUserInput(size uint) [][]int {
	matrix := make([][]int, size)

	for i := range matrix {
		matrix[i] = make([]int, size)
		for j := range matrix[i] {
			fmt.Printf("Введіть [%d,%d]: ", i+1, j+1)
			fmt.Scan(&matrix[i][j])
		}
	}

	return matrix
}

func printSquareMatrix(matrix [][]int) {
	for _, row := range matrix {
		fmt.Print("(")
		for _, val := range row {
			fmt.Printf("%4d ", val)
		}
		fmt.Println(")")
	}
}

func moveMaxElementsToSecondaryDiagonal(matrix [][]int) {
	size := len(matrix)

	var maxMainDiagonal int
	for i := 0; i < size; i++ {
		if matrix[i][i] > maxMainDiagonal {
			maxMainDiagonal = matrix[i][i]
		}
	}
	fmt.Println("Максимальний елемент:", maxMainDiagonal)
	fmt.Println("Симетрично переставляємо максимальні елементи з головної діагоналі на побічну:")
	for i := 0; i < size; i++ {
		if matrix[i][i] == maxMainDiagonal {
			temp := matrix[i][size-1-i]
			matrix[i][size-1-i] = maxMainDiagonal
			matrix[i][i] = temp
		}
	}
}
