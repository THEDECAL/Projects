<?php

namespace app\models;

use \yii\db\ActiveRecord;

class Matches extends ActiveRecord
{

    public static function tableName()
    {
        return 'matches';
    }

    public function rules()
    {
        return [
            ['date', 'required', 'message' => 'Это поле должно быть заполнено.'],
            //Проверка на присутствие выбранной комманды
            ['first_command_id', 'compare', 'compareValue' => 0, 'operator' => '!=', 'message' => 'Выберите комманду.'],
            ['second_command_id', 'compare', 'compareValue' => 0, 'operator' => '!=', 'message' => 'Выберите комманду.'],
            [['first_command_id', 'second_command_id', 'isDelete'], 'integer'],
            //Проверка на различие комманд
            ['first_command_id', 'compare', 'compareAttribute' => 'second_command_id', 'operator' => '!=', 'message' => 'Комманды "Кто" и "С кем" должны отличатся.'],
            ['second_command_id', 'compare', 'compareAttribute' => 'first_command_id', 'operator' => '!=', 'message' => 'Комманды "Кто" и "С кем" должны отличатся.'],
            //Проверка на правильность ввода счёта
            ['score', 'match', 'pattern' => '^[1-9]{1,1}[0-9]?\:[1-9]{1,1}[0-9]?$', 'message' => 'Не правильный формат.'],
            //
            [['date'], 'safe'],
            [['score'], 'string', 'max' => 5],
            [['first_command_id'], 'exist', 'skipOnError' => true, 'targetClass' => Commands::className(), 'targetAttribute' => ['first_command_id' => 'id']],
            [['second_command_id'], 'exist', 'skipOnError' => true, 'targetClass' => Commands::className(), 'targetAttribute' => ['second_command_id' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'first_command_id' => 'Кто*',
            'second_command_id' => 'С кем*',
            'score' => 'Счёт* (0:0)',
            'date' => 'Дата игры*',
            'isDelete' => 'Is Delete',
        ];
    }

    public function getGoals()
    {
        return $this->hasMany(Goals::className(), ['match_id' => 'id']);
    }

    public function getFirstCommand()
    {
        return $this->hasOne(Commands::className(), ['id' => 'first_command_id']);
    }

    public function getSecondCommand()
    {
        return $this->hasOne(Commands::className(), ['id' => 'second_command_id']);
    }

    public function getPenalizedPersons()
    {
        return $this->hasMany(PenalizedPersons::className(), ['match_id' => 'id']);
    }

    public static function find()
    {
        return new MatchesQuery(get_called_class());
    }
}
