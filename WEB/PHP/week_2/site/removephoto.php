<?php
require_once 'connect.php';

//Дописать проверку и фильтрование ведённых данных

if (isset($_GET['id'])){
	extract($_GET);
	$query = "UPDATE photos SET is_remove = TRUE WHERE id = ?";
	$stmt = $pdo->prepare($query);

	$stmt->bindValue(1, $id, PDO::PARAM_INT);
	$stmt->execute();
}

header('Location: ../index.php');
