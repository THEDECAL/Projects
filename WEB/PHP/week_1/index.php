<?php
foreach(getColors() as $color)
	echo "<div style='margin: 10px; width: 100px; height: 50px; background-color: $color'></div>";

$divtable = '<div><table>';
$month = 1;
for($i =0; $i < 2; $i++){
	$divtable .= '<tr>';
	for($j = 0; $j < 6; $j++){
		$divtable .= '<td>';
		$divtable .= getCalendarByCurrentYear($month);
		$divtable .= '</td>';
		$month++;
	}
	$divtable .= '</tr>';
}
$divtable .= '</table></div>';

echo $divtable;

function getColors(){
 	$colors = [ 'red', 'black', 'gray', 'green', 'yellow', 'purple', 'brown' ];
	$selectedColors = [];

	for($i = 0; $i < 4 ; $i++){
		$randColor = $colors[rand(0, sizeof($colors) - 1)];
		if(array_search($randColor, $selectedColors) === false)
			array_push($selectedColors, $randColor);
		else $i--;
	}

	return $selectedColors;
}

function getCalendarByCurrentYear($month){
	if($month >= 1 and $month <= 12){
		$year = date('Y');
		$daysInMonth = cal_days_in_month(CAL_GREGORIAN, $month, $year);
		$timestamp = mktime(0, 0, 0, $month, 1, $year);
		$dayInWeek = date('w', $timestamp) + 1;
		$namesOfdaysOfWeek = [ 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Вс' ];
		$daysOfWeek = sizeof($namesOfdaysOfWeek);

		$nameOfMonth = date('M', $timestamp);
		$calendar = '<div><table>';
		//Название месяца
		$calendar .= "<tr><td colspan=$daysOfWeek style='text-align: center;'>$nameOfMonth</td></tr>";
		//Дни недели
		$calendar .= '<tr>';
		foreach ($namesOfdaysOfWeek as $value)
			$calendar .= "<td style='font-weight: bold;'>$value</td>";
		$calendar .= '</tr>';
		//Дни месяца
		$day = 0; $shift = 0; $rows = $daysOfWeek - 1;
		for($i = 0; $i < $rows; $i++){
			$calendar .= '<tr>';
			for($j = 0; $j < $daysOfWeek; $j++){
				$calendar .= '<td style="text-align: center; font-weight: bold; border: 1px solid gray;">';
				if($day < $daysInMonth and $shift >= $dayInWeek){
					$color = ($j > 4)?'red':'';
					$calendar .= "<span style='color: $color'>". ++$day . '</span>';
				}
				else $calendar .= '&nbsp';
				$shift++;
				$calendar .= '</td>';
			}
			$calendar .= '</tr>';
		}
		$calendar .= '</table></div>';

		return $calendar;
	}
	else echo 'Введите число месяца от 1 до 12';

	return null;
}