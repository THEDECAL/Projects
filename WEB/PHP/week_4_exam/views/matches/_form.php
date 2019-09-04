<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\Matches */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="matches-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'first_command_id')->dropdownList($commands) ?>

    <?= $form->field($model, 'second_command_id')->dropdownList($commands) ?>

    <?= $form->field($model, 'date')->input('datetime-local') ?>

    <?= $form->field($model, 'score')->textInput(['maxlength' => true]) ?>

    <?= $model->isDelete = false ?>

    <div class="form-group">
        <?= Html::submitButton('Сохранить', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
