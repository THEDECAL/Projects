<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\Stadiums */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="stadiums-form">

    <?php $form = ActiveForm::begin(); ?>

    <div class='form-group' style="padding: 10px; border: 1px solid lightgray; border-radius: 10px;">

    <?= $form->field($model, 'city')->textInput(['maxlength' => true]) ?>

    <?= $form->field($model, 'name')->textInput(['maxlength' => true]) ?>

    <?= $model->isDelete = false ?>

	    <div class="form-group">
	        <?= Html::submitButton('Сохранить', ['class' => 'btn btn-success']) ?>
	    </div>

	</div>
    <?php ActiveForm::end(); ?>

</div>
