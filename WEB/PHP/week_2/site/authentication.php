<?php
$_POST = array_map('strip_tags', $_POST);
require_once 'connect.php';

$isLogIn = false;
session_start();
extract($_SESSION);

$login = '';
$password = '';
extract($_POST);

//Дописать проверку и фильтрование ведённых данных

if($isLogIn === false){
	$query = "SELECT id FROM logins WHERE login='$login' AND password='$password' LIMIT 1";
	$stmt = $pdo->query($query);
	$data = $stmt->fetch();

	if(isset($data['id'])){
		$_SESSION['isLogIn'] = true;
		$_SESSION['login_id'] = $data['id'];
		$_SESSION['login'] = $login;
	}
}
else session_destroy();

header('Location: ../index.php');
