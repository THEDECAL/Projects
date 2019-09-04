<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

//$lineUp = $model->getLineUps()->one();
//$line_up_id = ($lineUp === null)?'':$lineUp->id;
//$command = ($lineUp === null)?'':$lineUp->command_id;
// $year = ($lineUp === null)?date('Y'):$lineUp->year;
?>

<div class="players-form">

    <?php $form = ActiveForm::begin(); ?>

    <div class='form-group' style="padding: 10px; border: 1px solid lightgray; border-radius: 10px;">

    <?= $form->field($model, 'name')->textInput(['maxlength' => true]) ?>

    <?= $form->field($model, 'position_id')->dropdownList($positions); ?>

    <?= $form->field($model, 'command_id')->dropdownList($commands); ?>

    <?= $form->field($model, 'photo_filename')->fileInput() ?>

    <?= $model->isDelete = false ?>

    <div class="form-group">
        <?= Html::submitButton('Сохранить', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
