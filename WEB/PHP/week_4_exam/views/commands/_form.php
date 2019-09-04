<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\Commands */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="commands-form">

    <?php $form = ActiveForm::begin(); ?>


    <div class='form-group' style="padding: 10px; border: 1px solid lightgray; border-radius: 10px;">

    <?= $form->field($model, 'name')->textInput(['maxlength' => true]) ?>

    <?= $form->field($model, 'coach')->textInput(['maxlength' => true]) ?>

    <?= $form->field($model, 'emblem_filename')->fileInput() ?>
    
    <?= $form->field($model, 'home_stadium_id')->dropdownList($stadiums) ?>

    <?= $model->isDelete = false ?>

        <div class="form-group">
            <?= Html::submitButton('Сохранить', ['class' => 'btn btn-success']) ?>
        </div>

    </div>

    <?php ActiveForm::end(); ?>

</div>
