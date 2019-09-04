<?php

namespace app\models;

//use Yii;
use \yii\db\ActiveRecord;
//use app\models\Commands;
//use app\models\Positions;

class Players extends  ActiveRecord
{
    public const PHOTOS_DIR = '../views/photos/';
    public static function tableName()
    {
        return 'players';
    }

    public function rules()
    {
        return [
            ['name', 'required', 'message' => 'Поле должно быть заполнено.'],
            //Проверка на присутствие выбранной позиции
            ['position_id', 'compare', 'compareValue' => 0, 'operator' => '!=', 'message' => 'Выберите позицию.'],
            ['command_id', 'compare', 'compareValue' => 0, 'operator' => '!=', 'message' => 'Выберите комманду.'],
            //
            [['position_id', 'command_id', 'isDelete'], 'integer'],
            [['name'], 'string', 'max' => 64],
            [['photo_filename'], 'string', 'max' => 255],
            [['position_id'], 'exist', 'skipOnError' => true, 'targetClass' => Positions::className(), 'targetAttribute' => ['position_id' => 'id']],
            ['isDelete', 'default', 'value' => 0],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'position_id' => 'Позиция**',
            'command_id' => 'Комманда*',
            'name' => 'Имя*',
            'photo_filename' => 'Фото',
            'season_year' => 'Год сезона в составе',
            'isDelete' => 'Is Delete',
        ];
    }

    public function getPosition()
    {
        return $this->hasOne(Positions::className(), ['id' => 'position_id']);
    }
    public function getCommand()
    {
        return $this->hasOne(Commands::className(), ['id' => 'command_id']);
    }

    public static function find()
    {
        return new PlayersQuery(get_called_class());
    }

    //Загрузка игроков из текстового файла
    public function addManyPlayers()
    {
        $file = '../views/players_list.txt';

        $fileHandle = @fopen($file, 'r');
        if ($fileHandle) {
            try {
                $cnt = 0;
                while (($buffer = fgets($fileHandle)) !== false) {
                    $array_prop = preg_split("/^'|'[\S,\s]'/", trim($buffer), 4,PREG_SPLIT_NO_EMPTY);
                    $array_prop = preg_replace("/'/", '', $array_prop);

                    $positionName = $array_prop[0];
                    $playerName = $array_prop[1];
                    $commandName = $array_prop[2];
                    $imgUrl = $array_prop[3];
                    $filename = uniqid() . '.' . pathinfo($imgUrl, PATHINFO_EXTENSION);
                    $position_id = Positions::getPositionIdByName($positionName);
                    $command_id = Commands::getCommandIdByName($commandName);
                    $imgData = file_get_contents($imgUrl);

                    if(!$position_id || !$command_id || sizeof($imgData) === 0) continue;

                    if (file_put_contents(self::PHOTOS_DIR . $filename, $imgData) !== false) {
                        $player = new Players();
                        $player->name = $playerName;
                        $player->position_id = $position_id;
                        $player->command_id = $command_id;
                        $player->photo_filename = $filename;
                        $player->season_year = date('Y');

                        $player->save();
                    }
                    $cnt++;
                }
            } finally { fclose($fileHandle); }
        }
    }
}
