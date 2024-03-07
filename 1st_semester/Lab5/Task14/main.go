package main

import (
    "fmt"
    "math"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Labwork #5, Task #14")
	fmt.Println("Замінити всі додатні числа на їхні квадрати і після цього знайти два максимальних значення.")
	fmt.Println("1. Заповнити масив псевдовипадковими числами (попередньо ввести к-сть елементів масиву);")
	fmt.Println("2. Заповнити масив вручну (попередньо ввести к-сть елементів масиву)")
	fmt.Println("0. Вийти.")

	var choice int
	for {
		fmt.Print("Ваш вибір: ")
		fmt.Scanln(&choice)

		switch choice {
		case 1:
			fmt.Print("[1] Введіть розмір масиву: ")
			var sizeOfRND int
			fmt.Scanln(&sizeOfRND)
			rndArr := generatePseudoRandomArray(sizeOfRND)
			doTask14(choice, rndArr)
		case 2:
			fmt.Println("[2] Виберіть, як ви хочете заповнити масив(1 - в один рядок (через пробіл), 2 - кожен символ в новій строці (через \\n)): ")
			var choiceForCase2 int
			fmt.Scanln(&choiceForCase2)

			switch choiceForCase2 {
			case 1:
				fmt.Println("Вибрано заповнення в один рядок.")
				fmt.Println("Введіть числа, які ввести в масив:")
				oneLineArr := fillArrayInSingleLine()
				doTask14(choice, oneLineArr)
			case 2:
				fmt.Print("[2] Введіть розмір масиву: ")
				var size int
				fmt.Scanln(&size)
				fmt.Println("Вибрано заповнення по строкам.")
				fmt.Println("Введіть числа, які ввести в масив:")
				sepLineArr := fillArraySeparately(size)
				doTask14(choice, sepLineArr)
			default:
				fmt.Println("Ви ввели некоректне значення. Спробуйте будь ласка ще раз)")
			}
		case 0:
			fmt.Println("Виходжу.")
			os.Exit(0)
		default:
			fmt.Println("Ви ввели некоректне значення. Спробуйте будь ласка ще раз)")
		}
	}
}


func DoTask14(choice int, arr []int) {
	fmt.Printf("[%v] Друкую масив:\n", choice)
	PrintArray(arr)
	fmt.Println()
	fmt.Printf("[%v] Тепер друкую масив, у якому всі додатні числа піднесені до квадрату\n", choice)
	PrintArray(SquarePositiveNumbers(arr))
	fmt.Println()
	max1, max2 := FindTwoMaximums(arr)
	fmt.Printf("[%v] Тепер виведемо перший і другий максимум числа: %v.\n", choice, []int{max1, max2})
}



func PrintArray(arr []int) {
	for i := 0; i < len(arr); i++ {
		fmt.Printf("%d ", arr[i])
	}
	fmt.Println()
}

func FindTwoMaximums(arr []int) string {
	max1 := math.MinInt64
	max2 := math.MinInt64

	for i := 0; i < len(arr); i++ {
		if arr[i] > max1 {
			max2 = max1
			max1 = arr[i]
		} else if arr[i] > max2 {
			max2 = arr[i]
		}
	}

	return fmt.Sprintf("max1 = %v, max2 = %v", max1, max2)
}
func DoTask14(choice int, arr []int) {
	fmt.Printf("[%v] Друкую масив:\n", choice)
	PrintArray(arr)
	fmt.Println()
	fmt.Printf("[%v] Тепер друкую масив, у якому всі додатні числа піднесені до квадрату\n", choice)
	PrintArray(SquarePositiveNumbers(arr))
	fmt.Println()
	max1, max2 := FindTwoMaximums(arr)
	fmt.Printf("[%v] Тепер виведемо перший і другий максимум числа: %v.\n", choice, []int{max1, max2})
}


func GeneratePseudoRandomArray(size int) []int {
	array := make([]int, size)

	for i := 0; i < size; i++ {
		array[i] = rand.Intn(199) - 99 // Generates a random integer between -99 and 99
	}

	return array
}



func FillArrayInSingleLine() []int {
	var input string
	fmt.Scanln(&input)
	strArr := strings.Split(input, " ")
	var intArr []int

	for _, str := range strArr {
		num, _ := strconv.Atoi(str)
		intArr = append(intArr, num)
	}

	return intArr
}
func FillArraySeparately(size int) []int {
	array := make([]int, size)

	var n int
	for i := 0; i < size; i++ {
		fmt.Scan(&n)
		array[i] = n
	}

	return array
}

func squarePositiveNumbers(arr []int) []int {
	for i := 0; i < len(arr); i++ {
		if arr[i] > 0 {
			arr[i] = arr[i] * arr[i]
		}
	}
	return arr
}
