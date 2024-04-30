package main

import (
	"fmt"
)

type MyTime struct {
	hour   int
	minute int
	second int
}

func NewMyTime(h, m, s int) MyTime {
	return MyTime{hour: h, minute: m, second: s}
}

func (t MyTime) String() string {
	return fmt.Sprintf("%d:%02d:%02d", t.hour, t.minute, t.second)
}

func ToSecSinceMidnight(t MyTime) int {
	return t.hour*3600 + t.minute*60 + t.second
}

func FromSecSinceMidnight(t int) MyTime {
	const secPerDay = 60 * 60 * 24
	t %= secPerDay

	if t < 0 {
		t += secPerDay
	}
	h := t / 3600
	m := t / 60 % 60
	s := t % 60
	return NewMyTime(h, m, s)
}

func AddOneSecond(t MyTime) MyTime {
	return AddSeconds(t, 1)
}

func AddOneMinute(t MyTime) MyTime {
	t.minute++
	if t.minute >= 60 {
		t.minute = 0
		t.hour++
		if t.hour >= 24 {
			t.hour = 0
		}
	}
	return t
}

func AddOneHour(t MyTime) MyTime {
	t.hour++
	if t.hour >= 24 {
		t.hour = 0
	}
	return t
}

func AddSeconds(t MyTime, s int) MyTime {
	totalSeconds := t.hour*3600 + t.minute*60 + t.second

	totalSeconds += s

	newHour := totalSeconds / 3600 % 24
	newMinute := totalSeconds % 3600 / 60
	newSecond := totalSeconds % 60

	return NewMyTime(newHour, newMinute, newSecond)
}

func Difference(t1, t2 MyTime) int {
	totalSeconds1 := t1.hour*3600 + t1.minute*60 + t1.second
	totalSeconds2 := t2.hour*3600 + t2.minute*60 + t2.second

	difference := totalSeconds1 - totalSeconds2

	return difference
}

func IsInRange(start, finish, t MyTime) bool {
	if start.hour <= finish.hour {
		if t.hour > start.hour && t.hour < finish.hour {
			return true
		}
		if t.hour == start.hour && t.minute > start.minute {
			return true
		}
		if t.hour == start.hour && t.minute == start.minute && t.second >= start.second {
			return true
		}
		if t.hour == finish.hour && t.minute < finish.minute {
			return true
		}
		if t.hour == finish.hour && t.minute == finish.minute && t.second < finish.second {
			return true
		}
	} else {
		if (t.hour > start.hour || t.hour < finish.hour) ||
			(t.hour == finish.hour && t.minute < finish.minute) ||
			(t.hour == finish.hour && t.minute == finish.minute && t.second < finish.second) ||
			(t.hour == start.hour && t.minute > start.minute) ||
			(t.hour == start.hour && t.minute == start.minute && t.second >= start.second) {
			return true
		}
	}
	return false
}

func WhatLesson(mt MyTime) string {
	lessonsStart := []MyTime{
		NewMyTime(8, 0, 0),
		NewMyTime(9, 40, 0),
		NewMyTime(11, 20, 0),
		NewMyTime(13, 0, 0),
		NewMyTime(14, 40, 0),
		NewMyTime(16, 10, 0),
	}

	lessonsEnd := []MyTime{
		NewMyTime(9, 20, 0),
		NewMyTime(11, 0, 0),
		NewMyTime(12, 40, 0),
		NewMyTime(14, 20, 0),
		NewMyTime(16, 0, 0),
		NewMyTime(17, 30, 0),
	}

	if Difference(mt, lessonsStart[0]) < 0 {
		return "пари ще не почались"
	}

	if IsInRange(lessonsStart[0], lessonsEnd[0], mt) {
		return "1-а пара"
	}

	for i := 1; i < len(lessonsStart); i++ {
		if IsInRange(lessonsStart[i], lessonsEnd[i], mt) {
			return fmt.Sprintf("%d-а пара", i+1)
		}

		if IsInRange(lessonsEnd[i-1], lessonsStart[i], mt) {
			return fmt.Sprintf("перерва між %d-ою та %d-ою парами", i, i+1)
		}
	}

	return "пари вже кінчилися"
}

func main() {
	fmt.Println("Перевірка методу ToSecSinceMidnight:")
	time1 := NewMyTime(10, 30, 15)
	time2 := NewMyTime(5, 45, 20)
	fmt.Printf("З півночі по %v пройшло %v секунд.\n", time1, ToSecSinceMidnight(time1))
	fmt.Printf("З півночі по %v пройшло %v секунд.\n", time2, ToSecSinceMidnight(time2))
	fmt.Println()

	fmt.Println("Перевірка методу FromSecSinceMidnight:")
	totalSeconds := 30000 // 8:20:00
	fromSeconds := FromSecSinceMidnight(totalSeconds)
	fmt.Printf("Перевівши час з опівночі з секунд у формат годинника, отримуємо %v\n", fromSeconds)
	fmt.Println()

	fmt.Println("Перевірка методу AddOneSecond:")
	time3 := NewMyTime(23, 59, 59)
	fmt.Printf("Час до додавання однієї секунди: %v\n", time3)
	fmt.Printf("Час після додавання однієї секунди: %v\n", AddOneSecond(time3))
	fmt.Println()

	fmt.Println("Перевірка методу AddOneMinute:")
	time4 := NewMyTime(14, 59, 30)
	fmt.Printf("Час до додавання однієї хвилини: %v\n", time4)
	fmt.Printf("Час після додавання однієї хвилини: %v\n", AddOneMinute(time4))
	fmt.Println()

	fmt.Println("Перевірка методу AddOneHour:")
	time5 := NewMyTime(23, 55, 29)
	fmt.Printf("Час до додавання однієї години: %v\n", time5)
	fmt.Printf("Час після додавання однієї години: %v\n", AddOneHour(time5))
	fmt.Println()

	fmt.Println("Перевірка методу AddSeconds:")
	time6 := NewMyTime(5, 30, 45)
	secondsToAdd := 150
	fmt.Printf("Час до додавання %v секунд: %v\n", secondsToAdd, time6)
	fmt.Printf("Час після додавання %v секунд: %v\n", secondsToAdd, AddSeconds(time6, secondsToAdd))
	fmt.Println()

	fmt.Println("Перевірка методу IsInRange:")
	startTime := NewMyTime(14, 0, 0)
	finishTime := NewMyTime(10, 0, 0)
	checkTime := NewMyTime(2, 30, 0)
	isInRange := IsInRange(startTime, finishTime, checkTime)
	if isInRange {
		fmt.Printf("%v знаходиться у діапазоні між %v та %v\n", checkTime, startTime, finishTime)
	} else {
		fmt.Printf("%v не знаходиться у діапазоні між %v та %v\n", checkTime, startTime, finishTime)
	}
	fmt.Println()

	fmt.Println("Перевірка методу Difference:")
	time7 := NewMyTime(1, 31, 56)
	time8 := NewMyTime(23, 14, 4)
	difference := Difference(time7, time8)
	fmt.Printf("Різниця між %v та %v - %v секунд, або ж %v\n", time7, time8, difference, FromSecSinceMidnight(difference))
	fmt.Println()

	fmt.Println("Перевірка метода WhatLesson:")
	var time9 MyTime
	time9 = NewMyTime(7, 33, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(8, 45, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(9, 24, 5)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(10, 35, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(11, 5, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(12, 16, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(12, 53, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(14, 10, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(14, 33, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(15, 33, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(16, 3, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(16, 13, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
	time9 = NewMyTime(17, 43, 0)
	fmt.Printf("%v - %v\n", time9, WhatLesson(time9))
}
