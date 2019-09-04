<?php
require_once 'connect.php';

$where = (isset($_GET['mode']) and $_GET['mode'] === 'myphotos') ? "WHERE `login` = '$login'" : '';

$query = "SELECT * FROM photos_view $where";
$stmt = $pdo->query($query);
$photos = $stmt->fetchAll();

$dir_images = 'images/';

//Выгрузка фото в папку для фото и их отображение на странице
echo '<div class="card-columns">';
foreach ($photos as $p){
	extract($p);

	$filename = $dir_images . $file_name . '.' . $file_ext;

	//Для владельца ссылка на изменение фото
	$edit_ref = (isset($_SESSION['login']) and $_SESSION['login'] === $login) ?
			"<div>
				<button class='submit-button mx-2'>
					<img width='20px' src='icons/edit.png'>
				</button>
				<a href='site/removephoto.php?id=$id' alt='...'>
					<img width='20px' src='icons/remove.png'>
				</a>
			</div>" : '';

	echo "<form method='post' action='index.php?mode=editphoto'><div class='card mx-0' style='width: 20rem;'>
			<input name='id' type='hidden' value='$id'>
			<input name='name' type='hidden' value='$name'>
			<input name='description' type='hidden' value='$description'>
			<input name='file_name' type='hidden' value='$file_name'>
			<input name='file_ext' type='hidden' value='$file_ext'>
			<div class='card-header py-1'> $name </div>
			<div class='card-header py-0 text-right bg-transparent'>
				<small class='text-muted'> $login </small>
			</div>
			<img src='$filename' class='card-img-top p-1' alt='...'>
		  	<div class='card-body py-2'>
			    <p class='card-text'> $description </p>
			</div>
		  	<div class='d-flex justify-content-between card-footer py-0 bg-transparent'>
					<small class='text-muted my-1'>$date</small>
					$edit_ref
			</div>
		</div></form>";
}
echo '</div>';