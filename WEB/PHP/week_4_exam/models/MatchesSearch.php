<?php

namespace app\models;

//use app\models\Matches;
use yii\base\Model;
use yii\data\ActiveDataProvider;


class MatchesSearch extends Matches
{


    public function rules()
    {
        return [
            [['id', 'first_command_id', 'second_command_id', 'isDelete'], 'integer'],
            [['score', 'date'], 'safe'],
        ];
    }


    public function scenarios()
    {
        return Model::scenarios();
    }


    public function search($params) :ActiveDataProvider
    {
        $query = Matches::find()->where('isDelete = FALSE');

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        // grid filtering conditions
        $query->andFilterWhere([
            'id' => $this->id,
            'first_command_id' => $this->first_command_id,
            'second_command_id' => $this->second_command_id,
            'date' => $this->date,
            'isDelete' => $this->isDelete,
        ]);

        $query->andFilterWhere(['like', 'score', $this->score]);

        return $dataProvider;
    }
}
