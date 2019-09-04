<?php

namespace app\models;

use \yii\db\ActiveRecord;

class Positions extends ActiveRecord
{

    public static function tableName()
    {
        return 'positions';
    }

    public function rules()
    {
        return [
            ['name', 'required', 'message' => 'Поле дожно быть заполнено.'],
            ['name', 'trim'],
            [['isDelete'], 'integer'],
            [['name'], 'string', 'max' => 48],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Позиция',
            'isDelete' => 'Is Delete',
        ];
    }

    public static function getPositionIdByName($name)
    {
        $sql = 'SELECT id FROM positions WHERE name=:name';
        $position = Positions::findBySql($sql, [':name' => "$name"])->one();
        return ($position)?$position->id:0;
    }


    public static function find()
    {
        return new PositionsQuery(get_called_class());
    }
}
