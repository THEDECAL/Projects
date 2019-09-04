<div class="phones">
	<?php

	use app\models\Phone;
  use yii\helpers\Url;


  $addUrl = Url::to(['phones/add']);
  echo "<div class='col-md-3'>
          <div class='thumbnail' style='padding: 27% 0;'>
            <a href='$addUrl' style='margin: 50%'><img width=100% src='../views/phones/images/plus.png' alt='...'></a>
        </div>
      </div>";

	foreach($phones as $phone){
    $editUrl = Url::to(['phones/edit', 'id' => $phone->getId()]);
    $deleteUrl = Url::to(['phones/delete', 'id' => $phone->getId()]);
		echo "<div class='col-md-3'>
    			 <div class='thumbnail'>
    				<br>
      				<img width=100px height=300px src='{$phone->getPathToImage()}' alt='...'>
      				<div class='caption'>
        				<h3>{$phone->getBrand()}</h3>
        				<h6>{$phone->getModel()}</h6>
        				<p>...</p>
        				<h5>{$phone->getPrice()}грн.</h5>
        				<p><a href='$editUrl' class='btn btn-primary' role='button'>Изменить</a> <a href='$deleteUrl' class='btn btn-danger' role='button'>Удалить</a></p>
      			</div>
    			</div>
  			</div>";
	}
	?>
</div>
