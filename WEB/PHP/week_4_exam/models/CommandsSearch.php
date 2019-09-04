<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
//use app\models\Commands;
use app\models\Stadiums;

class CommandsSearch extends Commands
{

    public function rules()
    {
        return [
            [['id', 'home_stadium_id', 'isDelete'], 'integer'],
            [['name', 'coach', 'emblem_filename'], 'safe'],
        ];
    }

    public function scenarios()
    {
        // bypass scenarios() implementation in the parent class
        return Model::scenarios();
    }

    /**
     * Creates data provider instance with search query applied
     *
     * @param array $params
     *
     * @return ActiveDataProvider
     */
    public function search($params)
    {
        //$query = Commands::find();
        $query = Commands::find()->where('isDelete = FALSE');

        // add conditions that should always apply here

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            // uncomment the following line if you do not want to return any records when validation fails
            // $query->where('0=1');
            return $dataProvider;
        }

        // grid filtering conditions
        $query->andFilterWhere([
            'id' => $this->id,
            'home_stadium_id' => $this->home_stadium_id,
            'isDelete' => $this->isDelete,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'coach', $this->coach])
            ->andFilterWhere(['like', 'emblem_filename', $this->emblem_filename]);

        return $dataProvider;
    }
}
