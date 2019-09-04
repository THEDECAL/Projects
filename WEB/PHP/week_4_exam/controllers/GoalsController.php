<?php

namespace app\controllers;

use app\models\Players;
use app\models\Matches;
use Yii;
use app\models\Goals;
use yii\data\ActiveDataProvider;
use yii\helpers\ArrayHelper;
use yii\web\Controller;
use yii\web\NotFoundHttpException;
use yii\filters\VerbFilter;
use yii\filters\AccessControl;

/**
 * GoalsController implements the CRUD actions for Goals model.
 */
class GoalsController extends Controller
{
    private function getPlayers() :Array{
        $players = Players::find()->all();
        $playersAndCommands = [];
        foreach ($players as $player) {
            array_push($playersAndCommands, [
                'id' => $player->id,
                'name' => $player->name,
                'command_name' => $player->command->name
            ]);
        }
        $playersAndCommands = ArrayHelper::map($playersAndCommands, 'id', 'name', 'command_name');
        array_unshift($playersAndCommands, '');

        return $playersAndCommands;
    }
    private function getMatches() :Array{
//        $date =
        $matches = Matches::find()->where('date <= curdate()')->all();
        $matchesAndCommands = [];
        foreach ($matches as $match) {
            array_push($matchesAndCommands, [
                'id' => $match->id,
                'commands' => $match->firstCommand->name . ' - ' . $match->secondCommand->name,
                'date' => $match->date
            ]);
        }
        $matchesAndCommands = ArrayHelper::map($matchesAndCommands, 'id', 'commands', 'date');
        array_unshift($matchesAndCommands, '');

        return $matchesAndCommands;
    }
    /**
     * {@inheritdoc}
     */


    public function behaviors()
    {
        return [
            'access' => [
                'class' => AccessControl::className(),
                'denyCallback' => function () {
                    throw new HttpException(403,'Авторизируйтесь, чтобы вносить изменения.');
                },
                'only' => ['create', 'update', 'delete', 'view', 'index'],
                'rules' => [
                    [
                        'allow' => true,
                        'actions' => ['view', 'index'],
                        'roles' => ['?'],
                    ],
                    [
                        'allow' => true,
                        'actions' => ['view', 'index', 'create', 'update', 'delete'],
                        'roles' => ['@'],
                    ],
                ]
            ],
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                    'delete' => ['POST'],
                ],
            ],
        ];
    }

    /**
     * Lists all Goals models.
     * @return mixed
     */
    public function actionIndex()
    {
        $dataProvider = new ActiveDataProvider([
            'query' => Goals::find(),
        ]);

        return $this->render('index', [
            'dataProvider' => $dataProvider,
        ]);
    }

    /**
     * Displays a single Goals model.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionView($id)
    {
        $model = $this->findModel($id);
        $match = Matches::findOne($model->match_id);

        return $this->render('view', [
            'model' => $model,
            'player' => Players::findOne($model->player_id),
            'player_passed' => Players::findOne($model->player_passed_id),
            'match' => $match
        ]);
    }

    /**
     * Creates a new Goals model.
     * If creation is successful, the browser will be redirected to the 'view' page.
     * @return mixed
     */
    public function actionCreate()
    {
        $model = new Goals();

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['index']);
        }

        return $this->render('create', [
            'model' => $model,
            'players' => $this->getPlayers(),
            'matches' => $this->getMatches()
        ]);
    }

    /**
     * Updates an existing Goals model.
     * If update is successful, the browser will be redirected to the 'view' page.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionUpdate($id)
    {
        $model = $this->findModel($id);

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['index']);
        }

        return $this->render('update', [
            'model' => $model,
            'players' => $this->getPlayers(),
            'matches' => $this->getMatches()
        ]);
    }

    /**
     * Deletes an existing Goals model.
     * If deletion is successful, the browser will be redirected to the 'index' page.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionDelete($id)
    {
        $this->findModel($id)->delete();

        return $this->redirect(['index']);
    }

    /**
     * Finds the Goals model based on its primary key value.
     * If the model is not found, a 404 HTTP exception will be thrown.
     * @param integer $id
     * @return Goals the loaded model
     * @throws NotFoundHttpException if the model cannot be found
     */
    protected function findModel($id)
    {
        if (($model = Goals::findOne($id)) !== null) {
            return $model;
        }

        throw new NotFoundHttpException('The requested page does not exist.');
    }
}
