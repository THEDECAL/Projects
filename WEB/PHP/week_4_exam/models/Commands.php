<?php

namespace app\models;

use \yii\db\ActiveRecord;


class Commands extends ActiveRecord
{
    public const EMBLEMS_DIR = '../views/emblems/';
    public static function tableName()
    {
        return 'commands';
    }

    public function rules()
    {
        return [
            [['name', 'coach'], 'required', 'message' => 'Поле должно быть запонено.'],
            //Проверка на присутствие выбранной комманды
            ['home_stadium_id', 'compare', 'compareValue' => 0, 'operator' => '!=', 'message' => 'Выберите стадион.'],
            [['home_stadium_id', 'isDelete'], 'integer'],
            [['name'], 'string', 'max' => 32],
            [['coach'], 'string', 'max' => 64],
            [['emblem_filename'], 'string', 'max' => 255],
            [['home_stadium_id'], 'exist', 'skipOnError' => true, 'targetClass' => Stadiums::className(), 'targetAttribute' => ['home_stadium_id' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Название*',
            'coach' => 'Главный тренер*',
            'emblem_filename' => 'Эмблема',
            'home_stadium_id' => 'Домашний стадион*',
            'isDelete' => 'Is Delete',
        ];
    }

    public function getStadium()
    {
        return $this->hasOne(Stadiums::className(), ['id' => 'home_stadium_id']);
    }

    public function getPlayers()
    {
        return $this->hasMany(Players::className(), ['command_id' => 'id']);
    }

    public static function getCommandIdByName($name)
    {
        $sql = 'SELECT id FROM commands WHERE name=:name';
        $command = Commands::findBySql($sql, [':name' => "$name"])->one();
        return ($command)?$command->id:0;
    }

    public static function find()
    {
        return new CommandsQuery(get_called_class());
    }
}
