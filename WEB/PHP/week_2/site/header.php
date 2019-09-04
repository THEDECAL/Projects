<!-- Меню -->
<nav class="navbar navbar-light bg-dark mb-2">
	<div class="container">
		<a href="./" class="navbar-brand text-white">Фото-Галерея</a>
	  	<form class="form-inline" method="post" action="site/authentication.php">
			<?php
	        	$isLogIn = false;
	        	session_start();
	        	extract($_SESSION);

	        	if(!$isLogIn){
	        		//Форма аутентификации
	        		echo '<input class="form-control mx-1" name="login" id="logInLogin" placeholder="Логин">
	        			<input type="password" class="form-control mx-1" name="password" id="logInPassword" placeholder="Пароль">
	        			<button class="btn btn-outline-success my-2 my-sm-0 mx-1" 	type="submit" class="btn btn-primary" data-toggle="modal" data-target="#logInModal">Войти</button>';
	        	}
	        	else{
	        		//Кнопка действий
	        		echo "<div class='btn-group mx-1'>
					  		<button type='button' class='btn btn-success dropdown-toggle' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>$login</button>
							<div class='dropdown-menu'>
						    	<a class='dropdown-item' data-target='#addPhotoModal' href='index.php?mode=addphoto'>Добавить фото</a>
						    	<a class='dropdown-item' href='index.php?mode=myphotos'>Мои фото</a>
						    	<div class='dropdown-divider'></div>
						    	<a class='dropdown-item' href='site/authentication.php'>Выход</a>
					  		</div>
						</div>";
	        	}
	        ?>
			<button class="btn btn-outline-danger my-2 my-sm-0 mx-1" type="button" class="btn btn-primary" data-toggle="modal" data-target="#regInModal">Регестрация</button>
		</form>
	</div>
</nav>
<!-- Модальная форма регестрации -->
<div class="modal fade" id="regInModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Регестрация</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      	<form method="post" action="site/regin.php">
	      	<div class="modal-body">
			  	<div class="form-group">
			    	<div class="input-group mb-2">
				        <div class="input-group-prepend">
				        	<div class="input-group-text">E-Mail:&nbsp&nbsp</div>
				        </div>
				        <input required name="email" type="email" class="form-control" id="email" placeholder="Ваш E-Mail для восстановления...">
			        </div>
		      	</div>
			  	<div class="form-group">
			    	<div class="input-group mb-2">
				        <div class="input-group-prepend">
				        	<div class="input-group-text">Логин:&nbsp&nbsp</div>
				        </div>
				        <input required name="login" class="form-control" id="login" placeholder="Ваш логин для входа...">
			        </div>
		      	</div>
			  	<div class="form-group">
			    	<div class="input-group mb-2">
			        	<div class="input-group-prepend">
			        		<div class="input-group-text">Пароль:</div>
			        	</div>
			        	<input required name="password" type="password" class="form-control" id="password" placeholder="Ваш пароль для входа...">
			        </div>
		      	</div>
	      	</div>
	      	<div class="modal-footer">
	        <button type="submit" class="btn btn-primary">Зарегестрироваться</button>
	      	</div>
		</form>
    </div>
  </div>
