<!doctype html>
<html lang='ru'>
	<head>
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<title>Фото-Галерея</title>
		<link href="css/bootstrap.css" rel="stylesheet">
		<link href="css/stylesheet.css" rel="stylesheet">
		<script src="js/jquery.js"></script>
		<script src="js/bootstrap.js"></script>
	</head>
	<body>
		<header><?php require_once 'site/header.php'; ?></header>
		<div class="container">
			<?php
				$mode = '';
				extract($_GET);

				switch ($mode){
					case 'editphoto':
						require_once 'site/editphoto.php';
					break;
					case 'addphoto':
						require_once 'site/addphoto.php';
					break;
					default:
						require_once 'site/gallery.php';
					break;
				}
			?>
		</div>
		<footer><?php require_once 'site/footer.php'; ?></footer>
	</body>
</html>