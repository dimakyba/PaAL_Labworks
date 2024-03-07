package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	fmt.Println("Labwork #7")
	fmt.Println("Task #1, Variant #15")
	fmt.Println("Знайти і вивести суму елементів, що знаходяться на головній діагоналі матриці, та суму елементів, що знаходяться на побічній діагоналі матриці; вважати, що матриця гарантовано квадратна.\n")

	fmt.Print("Введіть розмір матриці (n x n): ")
	var size uint
	fmt.Scanln(&size)

	fmt.Println("Виберіть як ви хочете ввести масив:")
	fmt.Println("1. Вручну")
	fmt.Println("2. Автоматично, псевдо-випадковими числами")

	var choiceOfInput int
	fmt.Scanln(&choiceOfInput)

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
		fmt.Printf("Сума елементів головної діагоналі матриці: %d\n", getSumOfMainMatrixDiagonal(matrix))
		fmt.Printf("Сума елементів побічної діагоналі матриці: %d\n", getSumOfSecondaryMatrixDiagonal(matrix))
	}
}

func generateRandomSquareMatrix(size uint) [][]int {
	rand.Seed(time.Now().UnixNano())
	matrix := make([][]int, size)

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
			fmt.Scanln(&matrix[i][j])
		}
	}

	return matrix
}

func getSumOfMainMatrixDiagonal(matrix [][]int) int {
	sum := 0
	for i := range matrix {
		sum += matrix[i][i]
	}
	return sum
}

func getSumOfSecondaryMatrixDiagonal(matrix [][]int) int {
	sum := 0
	size := len(matrix)
	for i := range matrix {
		sum += matrix[i][size-1-i]
	}
	return sum
}

func printSquareMatrix(matrix [][]int) {
	for i := range matrix {
		fmt.Print("(")
		for j := range matrix[i] {
			fmt.Printf("%4d ", matrix[i][j])
		}
		fmt.Println(")")
	}
}
