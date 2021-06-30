import React from 'react'
import TodaysMenu from './TodaysMenu'

import { makeStyles } from '@material-ui/core'
import Grid from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'

const useStyles = makeStyles((theme) => ({
    main: {
        width: "90%",
        margin: "20px auto",
    },
    firstRow: {
        height: "27vh",
        borderRadius: "30px",
    },
    secondRow: {
        height: "20vh"
    }
}))

const Home = () => {
    const classes = useStyles()

    return (
        <Grid container className={classes.main}>
            <Grid item xs={12}>
                <TodaysMenu />
            </Grid>
            <Grid item xs={6} className={classes.firstRow}>
                <Typography>My Pantry</Typography>
            </Grid>
            <Grid item xs={6} className={classes.firstRow}>
                <Typography>Recipes</Typography>
            </Grid>
            <Grid item xs={6} className={classes.secondRow}>
                <Typography>Grocery List</Typography>
            </Grid>
            <Grid item xs={6} className={classes.secondRow}>
                <Typography>Meal Plan</Typography>
            </Grid>

        </Grid>
    )
}

export default Home