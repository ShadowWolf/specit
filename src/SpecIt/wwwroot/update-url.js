window.changeUrl = (url) => {
    console.log('Updating browser URI to ' + url);
    history.pushState(null, '', url);
}
